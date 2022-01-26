using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Other;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class OfficerController : Controller
    {
        private readonly IOfficerServices _officerServices;
        private const string ControllerName = "/officer";
        public OfficerController(IOfficerServices officerServices)
        {
            _officerServices = officerServices;
        }
        [HttpGet(ControllerName)]
        public async Task<IActionResult> Index()
        {
            var officerlist = await _officerServices.Getall();
            return Ok(officerlist);
        }
        [HttpPost($"{ControllerName}/Login")]
        public async Task<IActionResult> Login([FromBody]LoginParameter login)
        {
            string username = login.Username;
            string password = login.Password;
            var result = await _officerServices.LoginCheck(username, password);
            return Ok(result);
        }

    }
}
