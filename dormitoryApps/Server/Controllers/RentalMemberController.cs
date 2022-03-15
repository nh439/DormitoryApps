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
            return Ok(await _rentalMemberServices.GetByRentalId(Id));
        }
        [HttpGet(BaseUrl+"/Member/{Id}")]
        public async Task<IActionResult> GetByMember(long Id)
        {
            return Ok(await _rentalMemberServices.GetByMember(Id));
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]RentalMember item)
        {
            return Ok(await _rentalMemberServices.Create(item));
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task<IActionResult> Create([FromBody]IEnumerable<RentalMember> items)
        {
            return Ok(await _rentalMemberServices.Create(items));
        }
        [HttpPost(BaseUrl + "/Setmain")]
        public async Task<IActionResult> Setmain([FromBody] RentalMember item)
        {
            return Ok(await _rentalMemberServices.SetnewRentalIsMain(item));
        }

    }
}
