using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yape.Domain.Entities;

namespace Yape.Infrastructure.Interfaces
{
    public interface INotificationSenderFactory
    {
        INotificationSender GetClient(NotificationType type);
    }
}
