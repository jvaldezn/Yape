using AutoMapper;
using Yape.Application.DTOs;
using Yape.Application.Interfaces;
using Yape.Domain.Entities;
using Yape.Infrastructure.Interfaces;
using Yape.Transversal.Common;

namespace Yape.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper _mapper;
        private readonly INotificationSenderFactory _service;

        public NotificationService(IMapper mapper, INotificationSenderFactory service)
        {
            _mapper = mapper;
            _service = service;
        }

        public Response<NotificationDto> SendNotification(NotificationDto notificationDto)
        {
            try
            {
                var validationResults = Validator.ValidateNotification(notificationDto);
                if (validationResults.Any())
                {
                    return Response<NotificationDto>.Fail(string.Join("; ", validationResults));
                }

                var notification = _mapper.Map<Notification>(notificationDto);
                var client = _service.GetClient(notification.Type);
                client.Notify(notification);

                //commit
                return Response<NotificationDto>.Success(notificationDto, Messages.NotificationSent);
            }
            catch (Exception ex) {

                //rollback
                return Response<NotificationDto>.Fail(string.Format(Messages.UnexpectedError, ex.Message));
            }
        }
    }
}
