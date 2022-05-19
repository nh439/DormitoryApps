using dormitoryApps.Server.Securites;
using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationServices _notificationServices;
        private readonly ISessionServices _sessionServices;
        private readonly ILogger<NotificationController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly PermissionService _permissionService;
        private const string BaseUrl = "/api/Notification";

        public NotificationController(INotificationServices notificationServices,
            ILogger<NotificationController> logger,
            ISessionServices sessionServices,
            IHttpContextAccessor contextAccessor,
            PermissionService permissionService)
        {
            _notificationServices = notificationServices;
            _logger = logger;
            _sessionServices = sessionServices;
            _contextAccessor = contextAccessor;
            _permissionService = permissionService;

        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index()
        {
            try
            {
                string sessionId = _contextAccessor.HttpContext.Session.GetString("Id");
                bool permission = _permissionService.PermissionCheck(sessionId);
                if (!permission) return BadRequest();
                long userId = new long();
                await _sessionServices.GetCurrentlogin(sessionId).ContinueWith(x =>
                {
                    userId = x.Result.Id;
                });
                await Task.Delay(10);
                var res = await _notificationServices.GetForUserId(userId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl + "/all")]
        public async Task<IActionResult> Getall()
        {
            try
            {
                string sessionId = _contextAccessor.HttpContext.Session.GetString("Id");
                bool permission = _permissionService.PermissionCheck(sessionId);
                if (!permission) return BadRequest();
                bool isAdmin = false;
                await _sessionServices.GetCurrentlogin(sessionId).ContinueWith(x =>
                {
                    isAdmin = x.Result.Issuper;
                });
                await Task.Delay(10);
                if (!isAdmin) return BadRequest();
                var res = await _notificationServices.Getall();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl + "/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                string sessionId = _contextAccessor.HttpContext.Session.GetString("Id");
                bool permission = _permissionService.PermissionCheck(sessionId);
                if (!permission) return BadRequest();
                var currentuser = await _sessionServices.GetCurrentlogin(sessionId);
                var res = await _notificationServices.GetNotification(id);
                var attendee = res.Attendees.Where(x => x.UserId == currentuser.Id).FirstOrDefault() != null;
                if (!attendee && !currentuser.Issuper && !res.SendAll) return BadRequest();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Create")]
        public async Task<IActionResult> Create([FromBody] Notification item)
        {
            try
            {
                var res = await _notificationServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody] Notification item)
        {
            try
            {
                var res = await _notificationServices.Edit(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody] string notificationId)
        {
            try
            {
                string sessionId = _contextAccessor.HttpContext.Session.GetString("Id");
                bool permission = _permissionService.PermissionCheck(sessionId);
                if (!permission) return BadRequest();
                var currentuser = await _sessionServices.GetCurrentlogin(sessionId);
                var deletedObject = await _notificationServices.GetNotification(notificationId);
                if (deletedObject.SenderId != currentuser.Id && !currentuser.Issuper) return BadRequest();
                var delres = await _notificationServices.Delete(notificationId);
                return Ok(delres);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Deleteafter")]
        public async Task<IActionResult> Deleteafter([FromBody] int days)
        {
            try
            {
                string sessionId = _contextAccessor.HttpContext.Session.GetString("Id");
                bool permission = _permissionService.PermissionCheck(sessionId);
                if (!permission) return BadRequest();
                var currentuser = await _sessionServices.GetCurrentlogin(sessionId);
                if(!currentuser.Issuper) return BadRequest();
                var res = await _notificationServices.DeleteAfter(days);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Sender")]
        public async Task<IActionResult> GetBySender()
        {
            try
            {
                string sessionId = _contextAccessor.HttpContext.Session.GetString("Id");
                bool permission = _permissionService.PermissionCheck(sessionId);
                if (!permission) return BadRequest();
                var currentuser = await _sessionServices.GetCurrentlogin(sessionId);
                if (!currentuser.Issuper) return BadRequest();
                var res = await _notificationServices.GetBySender(currentuser.Id);
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
