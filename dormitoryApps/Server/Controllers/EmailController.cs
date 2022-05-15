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
            try
            {
                await _emailServices.SendAsync(item);
                return Ok(200);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }     
    }
}
