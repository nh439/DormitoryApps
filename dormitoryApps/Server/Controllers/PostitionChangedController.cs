using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class PostitionChangedController : Controller
    {
        private readonly IPostitionChangedService _postitionChangedService;
        private readonly ILogger<PostitionChangedController> _logger;
        private const string BaseUrl = "/api/PostitionChanged";

        public PostitionChangedController(IPostitionChangedService postitionChangedService, ILogger<PostitionChangedController> logger)
        {
            _postitionChangedService = postitionChangedService;
            _logger = logger;
        }
        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(long? officerId)
        {
           if(officerId.HasValue)
            {
                var res = await _postitionChangedService.GetByofficer(officerId.Value);
                return Ok(res);
            }
            var resall = await _postitionChangedService.Getall();
            return Ok(resall);

        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> Create([FromBody]PostitionChanged item)
        {
            return Ok(await _postitionChangedService.Create(item));
        }
    }
}
