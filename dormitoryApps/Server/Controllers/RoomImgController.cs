using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class RoomImgController : Controller
    {
        private readonly IRoomImgServices _RoomimgServices;
        private readonly ILogger<RoomImgController> _logger;
        private const string BaseUrl = "/api/RoomImg";

        public RoomImgController(IRoomImgServices roomimgServices, ILogger<RoomImgController> logger)
        {
            _RoomimgServices = roomimgServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl+"/{roomId}")]
        public async Task< IActionResult> Index(int roomId)
        {
            var res = await _RoomimgServices.GetByRoom(roomId);
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Id/{Id}")]
        public async Task< IActionResult> GetById(long Id)
        {
            var res = await _RoomimgServices.GetById(Id);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task< IActionResult> Create([FromBody]RoomImg item)
        {
            var res = await _RoomimgServices.Create(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task< IActionResult> Creates([FromBody]IEnumerable<RoomImg> item)
        {
        var res = await _RoomimgServices.Create(item);
        return Ok(res);
        }
         [HttpPost(BaseUrl+"/Update")]
        public async Task< IActionResult> Update([FromBody]RoomImg item)
        {
        var res = await _RoomimgServices.Update(item);
        return Ok(res);
        }
        [HttpPost(BaseUrl + "/UpdateCommit")]
        public async Task<IActionResult> Update([FromBody] IEnumerable<RoomImg> item)
        {
            var res = await _RoomimgServices.UpdateCommit(item);
            return Ok(res);
        } 
        [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody] long itemId)
        {
            var res = await _RoomimgServices.Delete(itemId);
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/DeleteByRoom")]
        public async Task<IActionResult> Delete([FromBody] int roomId)
        {
            var res = await _RoomimgServices.DeleteByRoom(roomId);
            return Ok(res);
        }

    }
}
