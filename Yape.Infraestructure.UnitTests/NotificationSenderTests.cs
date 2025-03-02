using Yape.Domain.Entities;
using Yape.Infrastructure.Client;
using Yape.Infrastructure.Interfaces;

namespace Yape.Infraestructure.UnitTests
{
    public class NotificationSenderTests
    {
        [Theory]
        [InlineData(NotificationType.SMS, "Sending SMS to John Doe: Test message")]
        [InlineData(NotificationType.EMAIL, "Sending Email to John Doe: Test message")]
        [InlineData(NotificationType.WHATSAPP, "Sending WhatsApp to John Doe: Test message")]
        [InlineData(NotificationType.CALL, "Calling to John Doe: Test message")]
        public void Notify_ShouldWriteCorrectMessage(NotificationType type, string expectedMessage)
        {
            var notification = new Notification
            {
                Recipient = new Entity { FullName = "John Doe" },
                Body = "Test message",
                Type = type
            };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                INotificationSender sender = type switch
                {
                    NotificationType.SMS => new SmsClient(),
                    NotificationType.EMAIL => new EmailClient(),
                    NotificationType.WHATSAPP => new WhatsAppClient(),
                    NotificationType.CALL => new CallClient(),
                    _ => throw new ArgumentException("Invalid type")
                };

                sender.Notify(notification);

                var output = sw.ToString().Trim();
                Assert.Equal(expectedMessage, output);
            }
        }
    }
}