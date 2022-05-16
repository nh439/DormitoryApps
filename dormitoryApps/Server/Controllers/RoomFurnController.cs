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
            try
            {
                if (id.HasValue)
                {
                    var resid = await _roomFurnServices.GetById(id.Value);
                    return Ok(resid);

                }
                var res = await _roomFurnServices.Getall();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/room/{id}")]
        public async Task<IActionResult> GetByRoom(int id)
        {
            try
            {
                var res = await _roomFurnServices.GetByRoom(id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/create")]
        public async Task<IActionResult> Create([FromBody]RoomFurn item)
        {
            try
            {
                var res = await _roomFurnServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/createmulit")]
        public async Task<IActionResult> Create([FromBody] IEnumerable<RoomFurn> items)
        {
            try
            {
                var res = await _roomFurnServices.Create(items);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody] RoomFurn item)
        {
            try
            {
                var res = await _roomFurnServices.Update(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
         [HttpPost(BaseUrl+"/UpdateMulit")]
        public async Task<IActionResult> Update([FromBody] IEnumerable<RoomFurn> items)
        {
            try
            {
                var res = await _roomFurnServices.UpdateRoom(items);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
         [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody] long furnId)
        {
            try
            {
                var res = await _roomFurnServices.Delete(furnId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
         [HttpPost(BaseUrl+"/DeleteMulit")]
        public async Task<IActionResult> Delete([FromBody] int roomId)
        {
            try
            {
                var res = await _roomFurnServices.DeleteRoom(roomId);
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
