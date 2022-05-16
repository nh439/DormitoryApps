using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class RoomTemplateController : Controller
    {
        private readonly IRoomTemplateServices _roomTemplateServices;
        private readonly ILogger<RoomTemplateController> _logger;
        private const string BaseUrl = "/api/RoomTemplate";

        public RoomTemplateController(IRoomTemplateServices roomTemplateServices, ILogger<RoomTemplateController> logger)
        {
            _roomTemplateServices = roomTemplateServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    return Ok(await _roomTemplateServices.GetById(id.Value));
                }
                return Ok(await _roomTemplateServices.GetNames());
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/all")]
        public async Task<IActionResult> Getall()
        {
            try
            {
                var res = await _roomTemplateServices.Getall();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var res = await _roomTemplateServices.GetByName(name);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Create")]
        public async Task<IActionResult> Create([FromBody] RoomTemplate template)
        {
            try
            {
                var res = await _roomTemplateServices.Create(template);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody] RoomTemplate template)
        {
            try
            {
                var res = await _roomTemplateServices.Update(template);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody]int templateId)
        {
            try
            {
                var res = await _roomTemplateServices.Delete(templateId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/AddTemplate")]
        public async Task<IActionResult> AddTemplate([FromBody] RoomTemplateAddition addition)
        {
            try
            {
                var res = await _roomTemplateServices.AddTemplate(addition.roomId, addition.roomName);
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
