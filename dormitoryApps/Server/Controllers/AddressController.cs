using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressServices _addressServices;
        private readonly ILogger<AddressController> _logger;
        private const string BaseUrl = "/api/address";

        public AddressController(IAddressServices addressServices, ILogger<AddressController> logger)
        {
            _addressServices = addressServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl+"/{Id}")]
        public async Task<IActionResult> Index(string Id)
        {
            try
            {
                var address = await _addressServices.GetById(Id);
                return Ok(address);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost($"{BaseUrl}/Create")]
        public async Task<IActionResult> Create([FromBody]Address address)
        {
            try
            {
                await _addressServices.Create(address);
                return Ok(true);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Something Went Wrong");
            }
        }
         [HttpPost($"{BaseUrl}/Update")]
        public async Task<IActionResult> Update([FromBody]Address item)
        {
            try
            {
                await _addressServices.Update(item);
                return Ok(true);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Something Went Wrong");
            }
        }

    }
}
