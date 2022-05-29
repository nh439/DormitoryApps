using dormitoryApps.Server.Securites;
using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IMeetingServices _meetingServices;
        private readonly ISessionServices _sessionServices;
        private readonly ILogger<NotificationController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly PermissionService _permissionService;
        private const string BaseUrl = "/api/Meeting";

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
                var invites = await _meetingServices.GetInvites(userId);
                return Ok(invites);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl + "/Sender")]
        public async Task<IActionResult> GetBySender()
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
                var res = await _meetingServices.GetBySender(userId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> GetMeeting([FromBody] long meetingId)
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
                var res = await _meetingServices.GetMeeting(meetingId);
                var x = res.Attendees.Where(x => x.OfficerId == userId).FirstOrDefault();
                if (x != null) return BadRequest();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Create")]
        public async Task<IActionResult> Create([FromBody] Meeting item)
        {
            var res = await _meetingServices.Create(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody] Meeting item)
        {
            var res = await _meetingServices.Update(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody] long meetingId)
        {
            var res = await _meetingServices.Delete(meetingId);
            return Ok(res);
        }

    }
}
