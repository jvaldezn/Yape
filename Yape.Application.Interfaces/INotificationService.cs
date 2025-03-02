using Yape.Application.DTOs;
using Yape.Transversal.Common;

namespace Yape.Application.Interfaces
{
    public interface INotificationService
    {
        Response<NotificationDto> SendNotification(NotificationDto notificationDto);
    }
}
