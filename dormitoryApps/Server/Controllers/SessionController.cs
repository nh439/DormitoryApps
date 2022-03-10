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
            var res = await _sessionService.Getall();
            return Ok(res.OrderByDescending(x => x.LoggedIn));
        }
        [HttpPost($"{BaseUrl}/Create")]
        public async Task<IActionResult> Create([FromBody] long UserId)
        {
            var res = await _sessionService.Createlogin(UserId);
            _accessor.HttpContext.Session.SetString("Id", res);
            return Ok(res);
        }
        [HttpGet(BaseUrl + "/Force/{Id}")]
        public async Task<IActionResult> Forcelogout(long Id)
        {
            var res = await _sessionService.ForceLogout(Id);
            _accessor.HttpContext.Session.Clear();
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/SuperForce")]
        public IActionResult SuperForcelogout([FromBody] int day)
        {
            var res = _sessionService.SuperForcedlogout(day);
            return Ok(res);
        }

        [HttpGet(BaseUrl + "/Get/{SessionId}")]
        public async Task<IActionResult> GetcurrentLogin(string SessionId)
        {

            var res = await _sessionService.GetCurrentlogin(SessionId);
            if (res != null)
            {
                res.Password = "PA$$WORD";
                res.Idx = "INDEX";
            }
            return Ok(res);
        }
        [HttpGet(BaseUrl + "/GetUser/{Id}")]
        public async Task<IActionResult> GetByUser(long Id)
        {
            var res = await _sessionService.GetByUser(Id);
            return Ok(res);
        }
        [HttpPost($"{BaseUrl}/Permissioncheck")]
        public IActionResult Getpermission([FromBody] string SessionId)
        {
            var res = _permissionService.PermissionCheck(SessionId);
            if (!res)
            {
                return BadRequest("Authencation Failed");
            }
            return Ok(res);
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> GetWithAdvancedSearch([FromBody] SessionAdvancedSearchCriteria criteria)
        {
            var res = await _sessionService.GetWithAdvanceSearch(criteria);
            return Ok(res);
        }
        [HttpPost($"{BaseUrl}/Delete")]
        public IActionResult Delete([FromBody] int month)
        {
            var res =  _sessionService.DeleteAfterMonth(month);
            return Ok(res);
        }
    }
}
