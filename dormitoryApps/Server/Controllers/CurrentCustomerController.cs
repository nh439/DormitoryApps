using dormitoryApps.Server.Securites;
using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using PagedList;

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
        public async Task<IActionResult> Index(int? page)
        {
            try
            {
                var result = await _currentCustomerServices.Getall();
                if (page.HasValue)
                {
                    return Ok(result.ToPagedList(page.Value, 20));
                }
                return Ok(result);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }       
        [HttpGet(BaseUrl +"/{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            try
            {
                var result = await _currentCustomerServices.GetById(Id);
                return Ok(result);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Room/{Id}")]
        public async Task<IActionResult> GetByroom(int Id)
        {
            try
            {
                var result = await _currentCustomerServices.GetByRoom(Id);
                return Ok(result);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> Create([FromBody]CurrentCustomer item)
        {
            try
            {
                var result = await _currentCustomerServices.Create(item);
                return Ok(result);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody] CurrentCustomer item)
        {
            try
            {
                if (item.Imgs != null)
                {
                    var results = await _currentCustomerServices.UpdateWithImg(item);
                    return Ok(results);
                }
                var result = await _currentCustomerServices.Update(item);
                return Ok(result);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }

        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody]string Id)
        {
            try
            {
                var res = await _currentCustomerServices.Delete(Id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        
        [HttpGet(BaseUrl+"/idlist")]
        public async Task<IActionResult> GetIdList()
        {
            try
            {
                var res = await _currentCustomerServices.GetIdList();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }

    }
}
