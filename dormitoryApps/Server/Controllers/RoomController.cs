using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PagedList.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomServices _roomServices;
        private readonly ILogger<RoomController> _logger;
        private const string BaseUrl = "/api/Room";

        public RoomController(IRoomServices roomServices, ILogger<RoomController> logger)
        {
            _roomServices = roomServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl)]
        public async Task< IActionResult> Index(int ? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var rid = await _roomServices.GetById(id.Value);
                    return Ok(rid);
                }
                var res = await _roomServices.Getall();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+ "/building/{buildingId}")]
        public async Task<IActionResult> GetByBuilding(int buildingId,int? page)
        {
            try
            {
                var res = await _roomServices.GetByBuilding(buildingId);
                if (page.HasValue)
                {
                    var pagedRes = res.OrderBy(x => x.RoomName).OrderBy(x => x.Floor).ToPagedList(page.Value, 20);
                    return Ok(pagedRes);
                }
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/air")]
        public async Task<IActionResult> GetHasAircondition()
        {
            try
            {
                var res = await _roomServices.GetHasAircondition();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Enabled")]
        public async Task<IActionResult> GetEnabled()
        {
            try
            {
                var res = await _roomServices.GetEnabled();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]Room item)
        {
            try
            {
                var res = await _roomServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody]Room item)
        {
            try
            {
                var res = await _roomServices.Update(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody]int RoomId)
        {
            try
            {
                var res = await _roomServices.Delete(RoomId);
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
