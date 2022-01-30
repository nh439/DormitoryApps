using dormitoryApps.Server.Securites;
using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class CurrentCustomerController : Controller
    {
        private readonly ICurrentCustomerServices _currentCustomerServices;
        private readonly ILogger<CurrentCustomerController> _logger;
        private readonly PermissionService _permissionService;
        private const string BaseUrl = "/api/currentcustomer";

        public CurrentCustomerController(ICurrentCustomerServices currentCustomerServices, ILogger<CurrentCustomerController> logger, PermissionService permissionService)
        {
            _currentCustomerServices = currentCustomerServices;
            _logger = logger;
            _permissionService = permissionService;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index()
        {          
            var result = await _currentCustomerServices.Getall();
            return Ok(result);
        }
        [HttpGet(BaseUrl +"/{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var result = await _currentCustomerServices.GetById(Id);
            return Ok(result);
        }
        [HttpGet(BaseUrl+"/Room/{Id}")]
        public async Task<IActionResult> GetByroom(int Id)
        {
            var result = await _currentCustomerServices.GetByRoom(Id);
            return Ok(result);
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> Create([FromBody]CurrentCustomer item)
        {
            var result = await _currentCustomerServices.Create(item);
            return Ok(result);
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody] CurrentCustomer item)
        {
            if(item.Imgs != null)
            {
                var results = await _currentCustomerServices.UpdateWithImg(item);
                return Ok(results);
            }
            var result = await _currentCustomerServices.Update(item);
            return Ok(result);

        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody]string Id)
        {
            var res = await _currentCustomerServices.Delete(Id);
            return Ok(res);
        }

    }
}
