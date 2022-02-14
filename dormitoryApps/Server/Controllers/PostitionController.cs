using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class PostitionController : Controller
    {
        private readonly IPostitionServices _postitionServices;
        private readonly ILogger<PostitionController> _logger;
        private const string BaseUrl = "/api/Postition";
        public PostitionController(IPostitionServices postitionServices,
            ILogger<PostitionController> logger)
        {
            _postitionServices = postitionServices;
            _logger = logger;
        }
        [HttpGet(BaseUrl)]
        public async Task< IActionResult> Index(int? id)
        {
            if(id.HasValue)
            {
                var resId = await _postitionServices.GetById(id.Value);
                return Ok(resId);
            }
            var res = await _postitionServices.Getall();
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Department/{Id}")]
        public async Task< IActionResult> getByDepartment(int Id)
        {
            var res = await _postitionServices.GetByDepartment(Id);
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Line/{Id}")]
        public async Task< IActionResult> getByLine(int Id)
        {
            var res = await _postitionServices.GetByPostitionLine(Id);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]Postition postition)
        {
            var res = await _postitionServices.Create(postition);
            return Ok(res);
        }
         [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody]Postition postition)
        {
            var res = await _postitionServices.Update(postition);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Update([FromBody]int postitionId)
        {
            var res = await _postitionServices.Deleted(postitionId);
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Next/{id}")]
        public async Task<IActionResult> Next(int id)
        {
            var res = await _postitionServices.GetNextPostition(id);
            return Ok(res);
        }


    }
}
