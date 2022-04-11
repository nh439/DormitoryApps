using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class RentalAccountController : Controller
    {
        private readonly IRentalAccountServices _rentalAccountServices;
        private readonly ILogger<RentalAccountController> _logger;
        private const string BaseUrl = "/api/RentalAccount";

        public RentalAccountController(IRentalAccountServices rentalAccountServices, ILogger<RentalAccountController> logger)
        {
            _rentalAccountServices = rentalAccountServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl+"/{Id}")]
        public async Task<IActionResult> Index(string Id)
        {
            var res = await _rentalAccountServices.Get(Id);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]RentalAccount item)
        {
            var res = await _rentalAccountServices.Create(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody]RentalAccount item)
        {
            var res = await _rentalAccountServices.Update(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody]string itemId)
        {
            var res = await _rentalAccountServices.Delete(itemId);
            return Ok(res);
        }

    }
}
