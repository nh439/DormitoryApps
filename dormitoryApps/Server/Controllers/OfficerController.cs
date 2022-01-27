using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class OfficerController : Controller
    {
        private readonly IOfficerServices _officerServices;
        private const string ControllerName = "/api/officer";
        private readonly ILogger<OfficerController> _logger;
        private readonly IHttpContextAccessor _accessor;
        public OfficerController(IOfficerServices officerServices,
            ILogger<OfficerController> logger,
            IHttpContextAccessor accessor)
        {
            _officerServices = officerServices;
            _logger = logger;
            _accessor = accessor;
        }
        [HttpGet(ControllerName)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var officerlist = await _officerServices.Getall();
                return Ok(officerlist);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Insert Incomplete");
            }
        }
        [HttpPost($"{ControllerName}/Login")]
        public async Task<IActionResult> Login([FromBody]LoginParameter login)
        {
            try
            {
                string username = login.Username;
                string password = login.Password;
                var result = await _officerServices.LoginCheck(username, password);
                return Ok(result);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Insert Incomplete");
            }
        }
        [HttpPost($"{ControllerName}/Create")]
        public async Task<IActionResult> Create([FromBody]Officer officer)
        {
            try
            {
                var result = await _officerServices.Create(officer);
                return Ok(result);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Insert Incomplete");
            }

        }
        [HttpPost($"{ControllerName}/Update")]
        public async Task<IActionResult> Update([FromBody]Officer officer)
        {
            try
            {
                var result = await _officerServices.Update(officer);
                return Ok(result);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Insert Incomplete");
            }

        }

        [HttpGet(ControllerName+"/{Id}")]
        public async Task<IActionResult> GetById(long Id)
        {
            if(!string.IsNullOrEmpty(_accessor.HttpContext.Session.GetString("Id")))
            {
                try
                {
                    var result = await _officerServices.GetById(Id);
                    return Ok(result);
                }
                catch (Exception x)
                {
                    _logger.LogError(x, x.Message);
                    return StatusCode(500,x.Message);
                }
            }
            return BadRequest();
        }

    }
}
