using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankServices _bnkServices;
        private readonly ILogger<BankController> _logger;
        private const string BaseUrl = "/api/bank";

        public BankController(IBankServices bnkServices, ILogger<BankController> logger)
        {
            _bnkServices = bnkServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    return Ok(await _bnkServices.Get(id.Value));
                }
                return Ok(await _bnkServices.Get());
            }
            catch(Exception x)
            {
                _logger.LogError(x.Message,x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]Bank item)
        {
            try
            {
                return Ok(await _bnkServices.Create(item));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            try
            {
                return Ok(await _bnkServices.Delete(id));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }

    }
}
