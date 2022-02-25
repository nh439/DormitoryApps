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
            if(Id.HasValue)
            {
                return Ok(await _roomfurnTemplateServices.GetById(Id.Value));
            }
            return Ok(await _roomfurnTemplateServices.Getall());
        }
        [HttpGet(BaseUrl+"/Type/{name}")]
        public async Task<IActionResult> GetByTypeName(string typeName)
        {
            var res = await _roomfurnTemplateServices.GetByType(typeName);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]RoomfurnTemplate template)
        {
            var res = await _roomfurnTemplateServices.Create(template);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]IEnumerable<RoomfurnTemplate> templates)
        {
            var res = await _roomfurnTemplateServices.Create(templates);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody]RoomfurnTemplate template)
        {
            var res = await _roomfurnTemplateServices.Update(template);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody]long itemId)
        {
            var res = await _roomfurnTemplateServices.Delete(itemId);
            return Ok(res);
        }
        [HttpPost(BaseUrl+ "/DeleteTemplate")]
        public async Task<IActionResult> DeleteTemplate([FromBody]int roomId)
        {
            var res = await _roomfurnTemplateServices.DeleteTemplate(roomId);
            return Ok(res);
        }


    }
}
