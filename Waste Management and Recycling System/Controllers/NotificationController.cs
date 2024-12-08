using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waste_Management_and_Recycling_System.Services;

namespace Waste_Management_and_Recycling_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetNotificationsById(int userId)
        {
            var noti= await _notificationService.GetNotificationsByUserId(userId);
            if(noti==null)
                return NotFound();
            return Ok(noti);
        }
    }
}
