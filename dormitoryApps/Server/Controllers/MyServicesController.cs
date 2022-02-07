using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class MyServicesController : Controller
    {
        private readonly IMyServicesServices _myServicesServices;
        private readonly ILogger<MyServicesController> _logger;
        private const string BaseUrl = "/api/MyServices";

        public MyServicesController(IMyServicesServices myServicesServices, ILogger<MyServicesController> logger)
        {
            _myServicesServices = myServicesServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(long? id)
        {
            if(id.HasValue)
            {
                var service = await _myServicesServices.GetById(id.Value);
                return Ok(service);
            }
            var res = await _myServicesServices.Getall();
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]MyServices item)
        {
            var res = await _myServicesServices.Create(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody] MyServices item)
        {
            var res = await _myServicesServices.Update(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody] long itemId)
        {
            var res = await _myServicesServices.Delete(itemId);
            return Ok(res);
        }

    }
}
