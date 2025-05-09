using CapestoneProject.Interfaces;
using CapestoneProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapestoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationServices _notificationServices;
        public NotificationController(INotificationServices notificationServices)
        {
            _notificationServices = notificationServices;
        }
        /// <summary>
        /// Retrieves all notifications list belonging to a specific iuserId
        /// </summary>
        /// <param name="userId">The ID to get all notifications for userId</param>
        /// <returns>A list of notifications based on the specified userId</returns>
        /// <response code="200">Returns the notification list based on the Id</response>
        /// <response code="404">If no notification is found based on the Id</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("user-notifications/{userId}")]
        public async Task<IActionResult> GetAllNotificationByIdAsync(int userId)
        {
            try
            {
                var notification = await _notificationServices.GetAllNotificationByIdAsync(userId);
                return Ok(notification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
