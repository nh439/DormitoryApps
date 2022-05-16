using dormitoryApps.Server.Securites;
using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class ChangePasswordHistoryController : Controller
    {
        private readonly IChangePasswordHistoryService _changePasswordHistoryService;
        private readonly ILogger<ChangePasswordHistoryController> _logger;
        private readonly ISessionServices _sessionServices;
        private readonly IHttpContextAccessor _accessor;
        private const string BaseUrl = "/api/ChangePasswordHistory";

        public ChangePasswordHistoryController(IChangePasswordHistoryService changePasswordHistoryService, 
            ILogger<ChangePasswordHistoryController> logger,
            ISessionServices sessionServices,
            IHttpContextAccessor accessor)
        {
            _changePasswordHistoryService = changePasswordHistoryService;
            _logger = logger;
            _sessionServices = sessionServices;
            _accessor = accessor;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(long? userId)
        {
            try
            {
                if (userId.HasValue) return Ok(await _changePasswordHistoryService.Get(userId.Value));
                var current = await _sessionServices.GetCurrentlogin(_accessor.HttpContext.Session.GetString("Id"));
                if (current.Issuper) return Ok(await _changePasswordHistoryService.Get());
                return Ok(new List<ChangePasswordHistory>());
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> Delete([FromBody]int month)
        {
            try
            {
                var current = await _sessionServices.GetCurrentlogin(_accessor.HttpContext.Session.GetString("Id"));
                if (current.Issuper)
                {
                    var res = await _changePasswordHistoryService.Delete(month);
                    return Ok(res);
                }
                return Ok(0);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }

    }
}
