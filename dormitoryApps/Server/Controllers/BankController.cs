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
            if(id.HasValue)
            {
                return Ok(await _bnkServices.Get(id.Value));
            }
            return Ok(await _bnkServices.Get());
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]Bank item)
        {
            return Ok(await _bnkServices.Create(item));
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            return Ok(await _bnkServices.Delete(id));
        }

    }
}
