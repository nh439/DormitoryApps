using dormitoryApps.Server.Securites;
using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberServices _memberServices;
        private readonly ILogger<MemberController> _logger;
        private readonly PermissionService _permissionService;
        private const string BaseUrl = "/api/Member";

        public MemberController(IMemberServices memberServices, ILogger<MemberController> logger, PermissionService permissionService)
        {
            _memberServices = memberServices;
            _logger = logger;
            _permissionService = permissionService;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(long? Id)
        {
            try
            {
                if (Id.HasValue) return Ok(await _memberServices.GetById(Id.Value));
                return Ok(await _memberServices.Getall());
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> GetIn([FromBody] IEnumerable<long> IdCollection)
        {
            try
            {
                return Ok(await _memberServices.GetIn(IdCollection));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]Member item)
        {
            try
            {
                return Ok(await _memberServices.Create(item));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task<IActionResult> Create([FromBody]IEnumerable<Member> items)
        {
            try
            {
                return Ok(await _memberServices.Create(items));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody] Member item)
        {
            try
            {
                return Ok(await _memberServices.Update(item));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            } 
        }

    }
}
