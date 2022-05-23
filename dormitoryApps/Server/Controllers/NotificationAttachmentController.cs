using dormitoryApps.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class NotificationAttachmentController : Controller
    {
        private readonly INotificationAttachmentServices _notificationAttachmentServices;
        private readonly ILogger<AddressController> _logger;
        private const string BaseUrl = "/api/NotificationAttachment";

        public NotificationAttachmentController(INotificationAttachmentServices notificationAttachmentServices, ILogger<AddressController> logger)
        {
            _notificationAttachmentServices = notificationAttachmentServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl+"/{notificationid}")]
        public async Task<IActionResult> Index(string notificationid)
        {
            try
            {
                var res = await _notificationAttachmentServices.GetByNotification(notificationid);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/GetAttachment/{id}")]
        public async Task<IActionResult> GetAttachment(string id)
        {
            try
            {
                var res = await _notificationAttachmentServices.GetAttachment(id);
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
