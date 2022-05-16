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
            try
            {
                var res = await _RoomimgServices.GetByRoom(roomId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Id/{Id}")]
        public async Task< IActionResult> GetById(long Id)
        {
            try
            {
                var res = await _RoomimgServices.GetById(Id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task< IActionResult> Create([FromBody]RoomImg item)
        {
            try
            {
                var res = await _RoomimgServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task< IActionResult> Creates([FromBody]IEnumerable<RoomImg> item)
        {
            try
            {
                var res = await _RoomimgServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
         [HttpPost(BaseUrl+"/Update")]
        public async Task< IActionResult> Update([FromBody]RoomImg item)
        {
            try
            {
                var res = await _RoomimgServices.Update(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/UpdateCommit")]
        public async Task<IActionResult> Update([FromBody] IEnumerable<RoomImg> item)
        {
            try
            {
                var res = await _RoomimgServices.UpdateCommit(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        } 
        [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody] long itemId)
        {
            try
            {
                var res = await _RoomimgServices.Delete(itemId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/DeleteByRoom")]
        public async Task<IActionResult> Delete([FromBody] int roomId)
        {
            try
            {
                var res = await _RoomimgServices.DeleteByRoom(roomId);
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
