using dormitoryApps.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionServices _sessionService;
        private const string BaseUrl = "/api/session";
        private readonly ILogger<SessionController> _logger;
        private readonly IHttpContextAccessor _accessor;
        public SessionController(ISessionServices sessionServices,
                                ILogger<SessionController> logger,
                                IHttpContextAccessor accessor)
        {
            _accessor= accessor;
            _sessionService = sessionServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index()
        {
            var res = await _sessionService.Getall();
            return Ok(res.OrderByDescending(x=>x.LoggedIn));
        }
        [HttpPost($"{BaseUrl}/Create")]
        public async Task<IActionResult> Create([FromBody]long UserId)
        {
            var res = await _sessionService.Createlogin(UserId);
            _accessor.HttpContext.Session.SetString("Id", res);
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Force/{Id}")]
        public async Task<IActionResult> Forcelogout(long Id)
        {
            var res = await _sessionService.ForceLogout(Id);
            _accessor.HttpContext.Session.Clear();
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Get/{SessionId}")]
        public async Task<IActionResult> GetcurrentLogin(string SessionId)
        {
            var res = await _sessionService.GetCurrentlogin(SessionId);
            return Ok(res);
        }
        [HttpGet(BaseUrl + "/GetUser/{Id}")]
        public async Task<IActionResult> GetByUser(long Id)
        {
            var res = await _sessionService.GetByUser(Id);
            return Ok(res);
        }
    }
}
