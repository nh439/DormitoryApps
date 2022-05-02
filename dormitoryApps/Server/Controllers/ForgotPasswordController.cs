using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private readonly IForgotPasswordServices _forgotPasswordServices;
        private readonly ILogger<ForgotPasswordController> _logger;
        private readonly IOfficerServices _officerServices;
        private const string BaseUrl = "/api/ForgotPassword";

        public ForgotPasswordController(IForgotPasswordServices forgotPasswordServices,
            ILogger<ForgotPasswordController> logger,
            IOfficerServices officerServices)
        {
            _forgotPasswordServices = forgotPasswordServices;
            _logger = logger;
            _officerServices = officerServices;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(long? Id,string? Token)
        {
            if (!Id.HasValue || string.IsNullOrEmpty(Token)) return BadRequest();
            var res = await _forgotPasswordServices.TokenCheck(Token, Id.Value);
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Get")]
        public async Task<IActionResult> Get(long? Id, string? Token)
        {
            if (!Id.HasValue || string.IsNullOrEmpty(Token)) return BadRequest();
            var res = await _forgotPasswordServices.GetByToken(Token, Id.Value);
            return Ok(res);
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> Create([FromBody] ForgotPassword item)
        {
            var res = await _forgotPasswordServices.Create(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody]long OfficerId)
        {
            var officer = await _officerServices.GetById(OfficerId);
            if (!officer.Issuper) return BadRequest();
            return Ok(await _forgotPasswordServices.Delete());
        }
    }
}
