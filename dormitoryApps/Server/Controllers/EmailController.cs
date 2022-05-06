using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Other;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailServices;
        private readonly ILogger<EmailController> _logger;
        private const string BaseUrl = "/api/Email";

        public EmailController(IEmailServices emailServices, ILogger<EmailController> logger)
        {
            _emailServices = emailServices;
            _logger = logger;
        }


        [HttpPost(BaseUrl)]
        public async Task<IActionResult> Index([FromBody]MailRequest item)
        {
            await _emailServices.SendAsync(item);
            return Ok(200);
        }
        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Test()
        {
            MailRequest request = new MailRequest
            {
                Body = "<h1>TEST01</h1>",
                DisplayName = "Display01",
                Subject = "TEST",
                ToEmail = new string[1] { "nithi.handsome@gmail.com" }
            };
            await _emailServices.SendAsync(request);
            return Ok(200);
        }
    }
}
