using Yape.Domain.Entities;

namespace Yape.Infrastructure.Interfaces
{
    public interface INotificationSender
    {
        void Notify(Notification notification);
    }
}
