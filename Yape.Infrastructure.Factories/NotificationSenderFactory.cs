using Microsoft.Extensions.DependencyInjection;
using Yape.Domain.Entities;

using Yape.Infrastructure.Client;
using Yape.Infrastructure.Interfaces;
using Yape.Transversal.Common;

namespace Yape.Infrastructure.Factories
{
    public class NotificationSenderFactory : INotificationSenderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public NotificationSenderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //public INotificationSender GetClient(NotificationType type)
        //{
        //    return type switch
        //    {
        //        NotificationType.SMS => _serviceProvider.GetRequiredService<SmsClient>(),
        //        NotificationType.EMAIL => _serviceProvider.GetRequiredService<EmailClient>(),
        //        NotificationType.WHATSAPP => _serviceProvider.GetRequiredService<WhatsAppClient>(),
        //        NotificationType.CALL => _serviceProvider.GetRequiredService<CallClient>(),
        //        _ => throw new ArgumentException("Invalid notification type")
        //    };
        //}

        public INotificationSender GetClient(NotificationType type)
        {
            if (TypeValues.NotificationValues.TryGetValue(type, out var client))
            {
                return (INotificationSender)_serviceProvider.GetRequiredService(client);
            }
            throw new ArgumentException("Tipo de comunicación no soportado");
        }
    }
}
