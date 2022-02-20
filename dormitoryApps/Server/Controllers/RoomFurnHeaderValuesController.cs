using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class RoomFurnHeaderValuesController : Controller
    {
        private readonly IRoomFurnHeaderValuesServices _roomFurnHeaderValuesServices;
        private readonly ILogger<RoomFurnController> _logger;
        private const string BaseUrl = "/api/RoomFurnHeaderValues";

        public RoomFurnHeaderValuesController(IRoomFurnHeaderValuesServices roomFurnHeaderValuesServices, ILogger<RoomFurnController> logger)
        {
            _roomFurnHeaderValuesServices = roomFurnHeaderValuesServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(long? Id)
        {
            dynamic res;
            if(Id.HasValue)
            {
                res = await _roomFurnHeaderValuesServices.GetById(Id.Value);
                return Ok(res);
            }
            res = await _roomFurnHeaderValuesServices.Getall();
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Header/{Id}")]
        public async Task<IActionResult> GetByHeader (long Id)
        {
            var res = await _roomFurnHeaderValuesServices.GetByHeader(Id);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]RoomFurnHeaderValues value)
        {
            var res = await _roomFurnHeaderValuesServices.Create(value);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task<IActionResult> Create([FromBody]IEnumerable<RoomFurnHeaderValues> values)
        {
            var res = await _roomFurnHeaderValuesServices.Create(values);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody] RoomFurnHeaderValues value)
        {
            var res = await _roomFurnHeaderValuesServices.Update(value);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody] long valueId)
        {
            var res = await _roomFurnHeaderValuesServices.Delete(valueId);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/DeleteByHeader")]
        public async Task<IActionResult> DeleteByHeader([FromBody] long HeaderId)
        {
            var res = await _roomFurnHeaderValuesServices.DeleteByHeader(HeaderId);
            return Ok(res);
        }

    }
}
