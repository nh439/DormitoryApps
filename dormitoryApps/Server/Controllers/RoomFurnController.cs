using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class RoomFurnController : Controller
    {
        private readonly IRoomFurnServices _roomFurnServices;
        private readonly ILogger<RoomFurnController> _logger;
        private const string BaseUrl = "/api/RoomFurn";
        public RoomFurnController(IRoomFurnServices roomFurnServices,
            ILogger<RoomFurnController> logger)
        {
            _logger= logger;
            _roomFurnServices= roomFurnServices;
        }
        [HttpGet(BaseUrl)]
        public async Task< IActionResult> Index(long? id)
        {
            if(id.HasValue)
            {
                var resid = await _roomFurnServices.GetById(id.Value);
                return Ok(resid);

            }
            var res = await _roomFurnServices.Getall();
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/room/{id}")]
        public async Task<IActionResult> GetByRoom(int id)
        {
            var res = await _roomFurnServices.GetByRoom(id);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/create")]
        public async Task<IActionResult> Create([FromBody]RoomFurn item)
        {
            var res = await _roomFurnServices.Create(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/createmulit")]
        public async Task<IActionResult> Create([FromBody] IEnumerable<RoomFurn> items)
        {
            var res = await _roomFurnServices.Create(items);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody] RoomFurn item)
        {
            var res = await _roomFurnServices.Update(item);
            return Ok(res);
        }
         [HttpPost(BaseUrl+"/UpdateMulit")]
        public async Task<IActionResult> Update([FromBody] IEnumerable<RoomFurn> items)
        {
            var res = await _roomFurnServices.UpdateRoom(items);
            return Ok(res);
        }
         [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody] long furnId)
        {
            var res = await _roomFurnServices.Delete(furnId);
            return Ok(res);
        }
         [HttpPost(BaseUrl+"/DeleteMulit")]
        public async Task<IActionResult> Delete([FromBody] int roomId)
        {
            var res = await _roomFurnServices.DeleteRoom(roomId);
            return Ok(res);
        }

    }
}
