using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yape.Domain.Entities;
using Yape.Infrastructure.Client;

namespace Yape.Transversal.Common
{
    public static class TypeValues
    {
        public static readonly Dictionary<NotificationType, Type> NotificationValues = new()
        {
            { NotificationType.SMS, typeof(SmsClient) },
            { NotificationType.EMAIL, typeof(EmailClient) },
            { NotificationType.WHATSAPP, typeof(WhatsAppClient) },
            { NotificationType.CALL, typeof(CallClient) }
        };
    }
}
