using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Yape.Domain.Entities
{
    public class Notification
    {
        public Entity? Sender { get; set; }
        public Entity? Recipient { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public NotificationType Type { get; set; }
    }
}
