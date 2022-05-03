using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
        [HttpPost(BaseUrl + "/PasswordCheck")]
        public async Task<IActionResult> PasswordCheck([FromBody]LoginParameter item)
        {
            string content = Encoding.ASCII.GetString(item.Content);
            string[] loginarr = content.Split('|');
            if (loginarr.Length != 3)
            {
                return BadRequest("Parameter Incorrect");
            }
            if (loginarr[2] != item.Reference)
            {
                return BadRequest("Parameter Incorrect");
            }
            long userId = long.Parse(loginarr[1]);
            int password = int.Parse(loginarr[0]);
            return Ok(await _forgotPasswordServices.PasswordCheck(password, userId));
        }
    }
}
