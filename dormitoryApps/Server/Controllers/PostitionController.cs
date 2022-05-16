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
            try
            {
                if (id.HasValue)
                {
                    var resId = await _postitionServices.GetById(id.Value);
                    return Ok(resId);
                }
                var res = await _postitionServices.Getall();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Department/{Id}")]
        public async Task< IActionResult> getByDepartment(int Id)
        {
            try
            {
                var res = await _postitionServices.GetByDepartment(Id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Line/{Id}")]
        public async Task< IActionResult> getByLine(int Id)
        {
            try
            {
                var res = await _postitionServices.GetByPostitionLine(Id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]Postition postition)
        {
            try
            {
                var res = await _postitionServices.Create(postition);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
         [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody]Postition postition)
        {
            try
            {
                var res = await _postitionServices.Update(postition);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Delete")]
        public async Task<IActionResult> Update([FromBody]int postitionId)
        {
            try
            {
                var res = await _postitionServices.Deleted(postitionId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Next/{id}")]
        public async Task<IActionResult> Next(int id)
        {
            try
            {
                var res = await _postitionServices.GetNextPostition(id);
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
