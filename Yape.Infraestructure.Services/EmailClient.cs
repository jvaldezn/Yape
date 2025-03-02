using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yape.Domain.Entities;
using Yape.Infrastructure.Interfaces;

namespace Yape.Infrastructure.Client
{
    public class EmailClient : INotificationSender
    {
        public void Notify(Notification notification)
        {
            Console.WriteLine($"Sending Email to {notification?.Recipient?.FullName}: {notification?.Body}");
        }
    }
}
