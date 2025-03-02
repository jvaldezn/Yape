using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yape.Application.DTOs;

namespace Yape.Transversal.Common
{
    public static class Validator
    {
        public static List<string> ValidateNotification(NotificationDto notificationDto)
        {
            var errors = new List<string>();

            if (notificationDto.Sender == null)
                errors.Add("El remitente es obligatorio.");
            else
            {
                if (string.IsNullOrWhiteSpace(notificationDto.Sender.Resource))
                    errors.Add("El identificador del remitente es obligatorio.");
                if (string.IsNullOrWhiteSpace(notificationDto.Sender.FullName))
                    errors.Add("El nombre completo del remitente es obligatorio.");
            }

            if (notificationDto.Recipient == null)
                errors.Add("El destinatario es obligatorio.");
            else
            {
                if (string.IsNullOrWhiteSpace(notificationDto.Recipient.Resource))
                    errors.Add("El identificador del destinatario es obligatorio.");
                if (string.IsNullOrWhiteSpace(notificationDto.Recipient.FullName))
                    errors.Add("El nombre completo del destinatario es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(notificationDto.Title))
                errors.Add("El título es obligatorio.");

            if (string.IsNullOrWhiteSpace(notificationDto.Body))
                errors.Add("El contenido del mensaje es obligatorio.");

            if (!Enum.IsDefined(typeof(NotificationTypeDto), notificationDto.Type))
                errors.Add("El tipo de notificación no es válido.");

            return errors;
        }
    }
}
