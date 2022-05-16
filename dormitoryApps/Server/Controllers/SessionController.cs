using dormitoryApps.Server.Services;
using Microsoft.AspNetCore.Mvc;
using dormitoryApps.Server.Securites;
using dormitoryApps.Shared.Model.Other;

namespace dormitoryApps.Server.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionServices _sessionService;
        private const string BaseUrl = "/api/session";
        private readonly ILogger<SessionController> _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly PermissionService _permissionService;
        public SessionController(ISessionServices sessionServices,
                                ILogger<SessionController> logger,
                                IHttpContextAccessor accessor, PermissionService permissionService)
        {
            _accessor = accessor;
            _sessionService = sessionServices;
            _logger = logger;
            _permissionService = permissionService;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var res = await _sessionService.Getall();
                return Ok(res.OrderByDescending(x => x.LoggedIn));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost($"{BaseUrl}/Create")]
        public async Task<IActionResult> Create([FromBody] long UserId)
        {
            try
            {
                var res = await _sessionService.Createlogin(UserId);
                _accessor.HttpContext.Session.SetString("Id", res);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl + "/Force/{Id}")]
        public async Task<IActionResult> Forcelogout(long Id)
        {
            try
            {
                var res = await _sessionService.ForceLogout(Id);
                _accessor.HttpContext.Session.Clear();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/SuperForce")]
        public IActionResult SuperForcelogout([FromBody] int day)
        {
            try
            {
                var res = _sessionService.SuperForcedlogout(day);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }

        [HttpGet(BaseUrl + "/Get/{SessionId}")]
        public async Task<IActionResult> GetcurrentLogin(string SessionId)
        {
            try
            {
                var res = await _sessionService.GetCurrentlogin(SessionId);
                if (res != null)
                {
                    res.Password = "PA$$WORD";
                    res.Idx = "INDEX";
                }
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl + "/GetUser/{Id}")]
        public async Task<IActionResult> GetByUser(long Id)
        {
            try
            {
                var res = await _sessionService.GetByUser(Id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost($"{BaseUrl}/Permissioncheck")]
        public IActionResult Getpermission([FromBody] string SessionId)
        {
            try
            {
                var res = _permissionService.PermissionCheck(SessionId);
                if (!res)
                {
                    return BadRequest("Authencation Failed");
                }
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> GetWithAdvancedSearch([FromBody] SessionAdvancedSearchCriteria criteria)
        {
            try
            {
                var res = await _sessionService.GetWithAdvanceSearch(criteria);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost($"{BaseUrl}/Delete")]
        public IActionResult Delete([FromBody] int month)
        {
            try
            {
                var res = _sessionService.DeleteAfterMonth(month);
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
