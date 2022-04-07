using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> Index()
        {
            var res = await _pastCustomerServices.Getall();
            return Ok(res);
        }
        [HttpGet(BaseUrl+ "/GetUnRefund")]
        public async Task<IActionResult> GetUnRefund()
        {
            var res = await _pastCustomerServices.GetUnRefund();
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Id/{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var res = await _pastCustomerServices.GetById(Id);
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Idlist")]
        public async Task<IActionResult> GetByIds()
        {
            return Ok(await _pastCustomerServices.GetIds());
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]PastCustomer item)
        {
            var res = await _pastCustomerServices.Create(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task<IActionResult> Creates([FromBody]IEnumerable<PastCustomer> items)
        {
            var res = await _pastCustomerServices.Create(items);
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody] PastCustomer item)
        {
            var res = await _pastCustomerServices.Update(item);
            return Ok(res);
        }
         [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody]string Id)
        {
            var res = await _pastCustomerServices.Delete(Id);
            return Ok(res);
        }



    }
}
