using AutoMapper;
using Moq;
using Yape.Infrastructure.Interfaces;
using Yape.Application.Interfaces;
using Yape.Application.Services;
using Yape.Application.DTOs;
using Yape.Transversal.Common;
using Yape.Domain.Entities;

namespace Yape.Application.UnitTests
{
    public class NotificationServiceTests
    {
        private readonly Mock<INotificationSenderFactory> _mockFactory;
        private readonly Mock<IMapper> _mockMapper;
        private readonly INotificationService _notificationService;

        public NotificationServiceTests()
        {
            _mockFactory = new Mock<INotificationSenderFactory>();
            _mockMapper = new Mock<IMapper>();

            _notificationService = new NotificationService(_mockMapper.Object, _mockFactory.Object);
        }

        [Fact]
        public void SendNotification_ShouldReturnError_WhenNotificationIsInvalid()
        {
            var invalidNotification = new NotificationDto();

            var response = _notificationService.SendNotification(invalidNotification);

            Assert.False(response.IsSuccess);
            Assert.NotEmpty(response.Message);
        }

        [Fact]
        public void SendNotification_ShouldSendSuccessfully_WhenNotificationIsValid()
        {
            var validNotificationDto = new NotificationDto
            {
                Sender = new EntityDto { Resource = "123", FullName = "Remitente" },
                Recipient = new EntityDto { Resource = "456", FullName = "Destinatario" },
                Title = "Título",
                Body = "Mensaje de prueba",
                Type = NotificationTypeDto.SMS
            };

            var validNotification = new Notification
            {
                Sender = new Entity { Resource = "123", FullName = "Remitente" },
                Recipient = new Entity { Resource = "456", FullName = "Destinatario" },
                Title = "Título",
                Body = "Mensaje de prueba",
                Type = NotificationType.SMS
            };

            var mockClient = new Mock<INotificationSender>();

            _mockMapper.Setup(m => m.Map<Notification>(validNotificationDto)).Returns(validNotification);
            _mockFactory.Setup(f => f.GetClient(validNotification.Type)).Returns(mockClient.Object);

            var response = _notificationService.SendNotification(validNotificationDto);

            Assert.True(response.IsSuccess);
            Assert.Equal(Messages.NotificationSent, response.Message);
            mockClient.Verify(c => c.Notify(It.IsAny<Notification>()), Times.Once);
        }
    }
}