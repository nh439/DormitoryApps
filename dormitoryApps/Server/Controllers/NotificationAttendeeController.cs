using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class NotificationAttendeeController : Controller
    {
        private readonly INotificationAttendeeServices _notificationAttendeeServices;
        private readonly ILogger<NotificationAttendeeController> _logger;
        private const string BaseUrl = "/api/NotificationAttendee";

        public NotificationAttendeeController(INotificationAttendeeServices notificationAttendeeServices, ILogger<NotificationAttendeeController> logger)
        {
            _notificationAttendeeServices = notificationAttendeeServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(long? userId, string? notificationId)
        {
            try
            {
                if (!userId.HasValue && string.IsNullOrEmpty(notificationId))
                {
                    return StatusCode(555, "Invalid Parameters");
                }
                if (userId.HasValue && !string.IsNullOrEmpty(notificationId))
                {
                    return Ok(await _notificationAttendeeServices.GetOne(userId.Value, notificationId));
                }
                else if (userId.HasValue)
                {
                    return Ok(await _notificationAttendeeServices.GetByUser(userId.Value));
                }
                else
                {
                    return Ok(await _notificationAttendeeServices.GetByNotification(notificationId))
                }
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Create")]
        public async Task<IActionResult> Create([FromBody] NotificationAttendee item)
        {
            try
            {
                var res = await _notificationAttendeeServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Creates")]
        public async Task<IActionResult> Create([FromBody] IEnumerable<NotificationAttendee> items)
        {
            try
            {
                var res = await _notificationAttendeeServices.Create(items);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody] string NotificationId)
        {
            try
            {
                var res = await _notificationAttendeeServices.Delete(NotificationId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Deletes")]
        public async Task<IActionResult> Create([FromBody]string[] NotificationId)
        {
            try
            {
                var res = await _notificationAttendeeServices.Delete(NotificationId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
    }
}
