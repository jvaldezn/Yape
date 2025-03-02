using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Smtp;
using Moq;
using Yape.Domain.Entities;
using Yape.Infrastructure.Client;
using Yape.Infrastructure.Factories;
using Yape.Infrastructure.Interfaces;

namespace Yape.Infraestructure.UnitTests
{
    public class NotificationSenderFactoryTests
    {
        private readonly Mock<IServiceProvider> _mockServiceProvider;
        private readonly NotificationSenderFactory _factory;
        public NotificationSenderFactoryTests()
        {
            _mockServiceProvider = new Mock<IServiceProvider>();

            _factory = new NotificationSenderFactory(_mockServiceProvider.Object);
        }

        [Theory]
        [InlineData(NotificationType.SMS, typeof(SmsClient))]
        [InlineData(NotificationType.EMAIL, typeof(EmailClient))]
        [InlineData(NotificationType.WHATSAPP, typeof(WhatsAppClient))]
        [InlineData(NotificationType.CALL, typeof(CallClient))]
        public void GetClient_ShouldReturnCorrectSender(NotificationType type, Type expectedType)
        {
            var mockSender = new Mock<INotificationSender>();

            _mockServiceProvider
                .Setup(x => x.GetService(It.IsAny<Type>()))
                .Returns((Type t) => Activator.CreateInstance(expectedType));

            var sender = _factory.GetClient(type);

            Assert.NotNull(sender);
            Assert.IsType(expectedType, sender);
        }

        [Fact]
        public void GetClient_ShouldThrowExceptionForInvalidType()
        {
            // Arrange
            _mockServiceProvider
                .Setup(x => x.GetService(It.IsAny<Type>()))
                .Returns(null);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _factory.GetClient((NotificationType)999));
        }
    }
}
