using System.Text.Json.Serialization;

namespace Yape.Application.DTOs
{
    public class NotificationDto
    {
        public EntityDto? Sender { get; set; }
        public EntityDto? Recipient { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public NotificationTypeDto Type { get; set; }
    }
}
