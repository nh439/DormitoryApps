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
            try
            {
                dynamic res;
                if (Id.HasValue)
                {
                    res = await _roomFurnHeaderValuesServices.GetById(Id.Value);
                    return Ok(res);
                }
                res = await _roomFurnHeaderValuesServices.Getall();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Header/{Id}")]
        public async Task<IActionResult> GetByHeader (long Id)
        {
            try
            {
                var res = await _roomFurnHeaderValuesServices.GetByHeader(Id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]RoomFurnHeaderValues value)
        {
            try
            {
                var res = await _roomFurnHeaderValuesServices.Create(value);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task<IActionResult> Create([FromBody]IEnumerable<RoomFurnHeaderValues> values)
        {
            try
            {
                var res = await _roomFurnHeaderValuesServices.Create(values);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody] RoomFurnHeaderValues value)
        {
            try
            {
                var res = await _roomFurnHeaderValuesServices.Update(value);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody] long valueId)
        {
            try
            {
                var res = await _roomFurnHeaderValuesServices.Delete(valueId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/DeleteByHeader")]
        public async Task<IActionResult> DeleteByHeader([FromBody] long HeaderId)
        {
            try
            {
                var res = await _roomFurnHeaderValuesServices.DeleteByHeader(HeaderId);
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
