using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class RoomfurnTemplateController : Controller
    {
        private readonly IRoomfurnTemplateServices _roomfurnTemplateServices;
        private readonly ILogger<RoomfurnTemplateController> _logger;
        private const string BaseUrl = "/api/RoomfurnTemplate";

        public RoomfurnTemplateController(IRoomfurnTemplateServices roomfurnTemplateServices, ILogger<RoomfurnTemplateController> logger)
        {
            _roomfurnTemplateServices = roomfurnTemplateServices;
            _logger = logger;
        }
        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(long? Id)
        {
            try
            {
                if (Id.HasValue)
                {
                    return Ok(await _roomfurnTemplateServices.GetById(Id.Value));
                }
                return Ok(await _roomfurnTemplateServices.Getall());
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Type/{name}")]
        public async Task<IActionResult> GetByTypeName(string typeName)
        {
            try
            {
                var res = await _roomfurnTemplateServices.GetByType(typeName);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Template/{Id}")]
        public async Task<IActionResult> GetByTemplate(int Id)
        {
            try
            {
                var res = await _roomfurnTemplateServices.GetByTemplate(Id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]RoomfurnTemplate template)
        {
            try
            {
                var res = await _roomfurnTemplateServices.Create(template);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Creates")]
        public async Task<IActionResult> Create([FromBody]IEnumerable<RoomfurnTemplate> templates)
        {
            try
            {
                var res = await _roomfurnTemplateServices.Create(templates);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody]RoomfurnTemplate template)
        {
            try
            {
                var res = await _roomfurnTemplateServices.Update(template);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody]long itemId)
        {
            try
            {
                var res = await _roomfurnTemplateServices.Delete(itemId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+ "/DeleteTemplate")]
        public async Task<IActionResult> DeleteTemplate([FromBody]int roomId)
        {
            try
            {
                var res = await _roomfurnTemplateServices.DeleteTemplate(roomId);
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
