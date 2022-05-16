using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace dormitoryApps.Server.Controllers
{
    public class PastCustomerController : Controller
    {
        private readonly IPastCustomerServices _pastCustomerServices;
        private readonly ILogger<PastCustomerController> _logger;
        private const string BaseUrl = "/api/PastCustomer";
        public PastCustomerController(IPastCustomerServices pastCustomerServices, ILogger<PastCustomerController> logger)
        {
            _pastCustomerServices = pastCustomerServices;
            _logger = logger;
        }
        [HttpGet(BaseUrl)]
        public async Task<ActionResult> Index(int? page)
        {
            try
            {
                var res = await _pastCustomerServices.Getall();
                if (page.HasValue)
                {
                    return Ok(res.OrderByDescending(x => x.Id).ToPagedList(page.Value, 20));
                }
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+ "/GetUnRefund")]
        public async Task<IActionResult> GetUnRefund()
        {
            try
            {
                var res = await _pastCustomerServices.GetUnRefund();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Id/{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            try
            {
                var res = await _pastCustomerServices.GetById(Id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Idlist")]
        public async Task<IActionResult> GetByIds()
        {
            try
            {
                return Ok(await _pastCustomerServices.GetIds());
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]PastCustomer item)
        {
            try
            {
                var res = await _pastCustomerServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task<IActionResult> Creates([FromBody]IEnumerable<PastCustomer> items)
        {
            try
            {
                var res = await _pastCustomerServices.Create(items);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody] PastCustomer item)
        {
            try
            {
                var res = await _pastCustomerServices.Update(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
         [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody]string Id)
        {
            try
            {
                var res = await _pastCustomerServices.Delete(Id);
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
