using RabbitMQMassTransit.Shared;

namespace RabbitMQMassTransit.Api.Models
{
    public class NotificationDto
    {
        public DateTime NotificationDate { get; set; }
        public string? NotificationMessage { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
