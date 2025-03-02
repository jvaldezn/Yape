using Yape.Domain.Entities;
using Yape.Infrastructure.Interfaces;

namespace Yape.Infrastructure.Client
{
    public class SmsClient : INotificationSender
    {
        public void Notify(Notification notification)
        {
            Console.WriteLine($"Sending SMS to {notification?.Recipient?.FullName}: {notification?.Body}");
        }
    }
}
