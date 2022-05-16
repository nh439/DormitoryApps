using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class InvoiceServiceController : Controller
    {
        private readonly IIServices _iiServices;
        private readonly ILogger<InvoiceServiceController> _logger;
        private const string BaseUrl = "/api/InvoiceService";
        public InvoiceServiceController(IIServices iServices, ILogger<InvoiceServiceController> logger)
        {
            _iiServices = iServices;
            _logger = logger;
        }
        [HttpGet(BaseUrl+"/Invoice/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            try
            {
                var res = await _iiServices.GetByInvoice(id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Service/{id}")]
        public async Task<IActionResult> GetByServices(long id)
        {
            try
            {
                var res = await _iiServices.GetByService(id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]dormitoryApps.Shared.Model.Entity.InvoiceService item)
        {
            try
            {
                var res = await _iiServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
         [HttpPost(BaseUrl+"/Creates")]
        public async Task<IActionResult> Creates([FromBody]IEnumerable<dormitoryApps.Shared.Model.Entity.InvoiceService> items)
        {
            try
            {
                var res = await _iiServices.Create(items);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody] dormitoryApps.Shared.Model.Entity.InvoiceService item)
        {
            try
            {
                var res = await _iiServices.Update(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
         [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody] dormitoryApps.Shared.Model.Entity.InvoiceService item)
        {
            try
            {
                var res = await _iiServices.Delete(item);
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
