using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class RentalMemberController : Controller
    {
        private readonly IRentalMemberServices _rentalMemberServices;
        private readonly ILogger<RentalMemberController> _logger;
        private const string BaseUrl = "/api/RentalMember";

        public const string ControllerName = "api/RentalMember";
        [HttpGet(BaseUrl+"/Rental/{Id}")]
        public async Task<IActionResult> Index(string Id)
        {
            try
            {
                return Ok(await _rentalMemberServices.GetByRentalId(Id));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Member/{Id}")]
        public async Task<IActionResult> GetByMember(long Id)
        {
            try
            {
                return Ok(await _rentalMemberServices.GetByMember(Id));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]RentalMember item)
        {
            try
            {
                return Ok(await _rentalMemberServices.Create(item));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task<IActionResult> Create([FromBody]IEnumerable<RentalMember> items)
        {
            try
            {
                return Ok(await _rentalMemberServices.Create(items));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Setmain")]
        public async Task<IActionResult> Setmain([FromBody] RentalMember item)
        {
            try
            {
                return Ok(await _rentalMemberServices.SetnewRentalIsMain(item));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }

    }
}
