using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace dormitoryApps.Server.Controllers
{
    public class OfficerController : Controller
    {
        private readonly IOfficerServices _officerServices;
        private const string ControllerName = "/api/officer";
        private readonly ILogger<OfficerController> _logger;
        private readonly IHttpContextAccessor _accessor;
        private readonly ISessionServices _sessionServices;
        public OfficerController(IOfficerServices officerServices,
            ILogger<OfficerController> logger,
            IHttpContextAccessor accessor, 
            ISessionServices sessionServices)
        {
            _officerServices = officerServices;
            _logger = logger;
            _accessor = accessor;
            _sessionServices = sessionServices;
        }
        [HttpGet(ControllerName)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var officerlist = await _officerServices.Getall();
                officerlist.ForEach(x =>
                {
                    x.Password = "PA$$WORD";
                    x.Idx = "INEDX";
                });
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
                string username =Encoding.ASCII.GetString(login.Username);
                string password =Encoding.ASCII.GetString(login.Password);
                var result = await _officerServices.LoginCheck(username, password);
                return Ok(result);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Insert Incomplete");
            }
        }
        [HttpGet($"{ControllerName}/logout")]
        public async Task<IActionResult> Logout()
        {
            await _sessionServices.SetLogout(_accessor.HttpContext.Session.GetString("Id"));
            _accessor.HttpContext.Session.Clear();
            return Redirect("/");  
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
                    result.Password = "PA$$WORD";
                    result.Idx = "INEDX";
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
        [HttpGet(ControllerName+"/User/{id}")]
        public async Task<IActionResult> GetByUsername(string id)
        {
            
                try
                {
                    var result = await _officerServices.GetByUsername(id);
                result.Password = "PA$$WORD";
                result.Idx = "INEDX";
                return Ok(result);
                }
                catch (Exception x)
                {
                    _logger.LogError(x, x.Message);
                    return StatusCode(500, x.Message);
                }
        }

    }
}
