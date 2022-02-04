using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class PostitionLineController : Controller
    {
        private readonly IPostitionLineServices _postitionLineServices;
        private readonly ILogger<PostitionLineController> _logger;
        private const string BaseUrl = "/api/PostitionLine";

        public PostitionLineController(IPostitionLineServices postitionLineServices, ILogger<PostitionLineController> logger)
        {
            _postitionLineServices = postitionLineServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(int? id)
        {
            if(id.HasValue)
            {
                var ress = await _postitionLineServices.GetById(id.Value);
                return Ok(ress);
            }
            var res = await _postitionLineServices.Getall();
            return Ok(res);

        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]PostitionLine item)
        {
            var res = await _postitionLineServices.Create(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody]PostitionLine item)
        {
            var res = await _postitionLineServices.Update(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Delete([FromBody]int id)
        {
            var res = await _postitionLineServices.Delete(id);
            return Ok(res);
        }



    }
}
