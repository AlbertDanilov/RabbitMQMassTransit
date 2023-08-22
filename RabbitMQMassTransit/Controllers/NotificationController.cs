using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQMassTransit.Api.Models;
using RabbitMQMassTransit.Shared;

namespace RabbitMQMassTransit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        public readonly IPublishEndpoint publishEndpoint;

        public NotificationController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Notify(NotificationDto notificationDto)
        {
            await publishEndpoint.Publish<INotificationCreated>(new
            {
                NotificationDate = notificationDto.NotificationDate,
                NotificationMessage = notificationDto.NotificationMessage,
                NotificationType = notificationDto.NotificationType
            });

            return Ok();
        }
    }
}
