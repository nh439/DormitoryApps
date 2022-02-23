using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class RoomFurnHeaderController : Controller
    {
        private readonly IRoomFurnHeaderServices _roomFurnHeaderServices;
        private readonly ILogger<RoomFurnHeaderController> _logger;
        private const string BaseUrl = "/api/RoomFurnHeader";
        public RoomFurnHeaderController(IRoomFurnHeaderServices roomFurnHeaderServices,
            ILogger<RoomFurnHeaderController> logger)
        {
            _roomFurnHeaderServices = roomFurnHeaderServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(long? Id)
        {
            dynamic res;
            if(Id.HasValue)
            {
                res = await _roomFurnHeaderServices.GetById(Id.Value);
                return Ok(res);
            }
            res = await _roomFurnHeaderServices.Getall();
            return Ok(res);

        }
        [HttpGet(BaseUrl+"/Contains/{keyword}")]
        public async Task<IActionResult> GecContains(string keyword)
        {
            var res = await _roomFurnHeaderServices.GetContains(keyword);
            return Ok(res);
        }
        [HttpGet(BaseUrl + "/Type/{name}")]
        public async Task<IActionResult> GetByType(string name)
        {
            var res = await _roomFurnHeaderServices.GetByType(name);
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Type")]
        public async Task<IActionResult> GetType()
        {
            var res = await _roomFurnHeaderServices.GetTypes();
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]RoomFurnHeader item)
        {
            var res = await _roomFurnHeaderServices.Create(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task<IActionResult> Create([FromBody]IEnumerable<RoomFurnHeader> items)
        {
            var res = await _roomFurnHeaderServices.Create(items);
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody]RoomFurnHeader item)
        {
            var res = await _roomFurnHeaderServices.Update(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody]long itemId)
        {
            var res = await _roomFurnHeaderServices.Delete(itemId);
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/DeleteByType")]
        public async Task<IActionResult> Delete([FromBody]string itemType)
        {
            var res = await _roomFurnHeaderServices.DeleteByType(itemType);
            return Ok(res);
        }

    }
}
