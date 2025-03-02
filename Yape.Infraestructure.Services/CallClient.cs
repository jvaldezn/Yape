using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yape.Domain.Entities;
using Yape.Infrastructure.Interfaces;

namespace Yape.Infrastructure.Client
{
    public class CallClient : INotificationSender
    {
        public void Notify(Notification notification)
        {
            Console.WriteLine($"Calling to {notification?.Recipient?.FullName}: {notification?.Body}");
        }
    }
}
