using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Server.Securites;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly IBuildingsServices _buildingsServices;
        private readonly ILogger<BuildingsController> _logger;
        private readonly PermissionService _permissionService;
        private const string BaseUrl = "/api/buildings";

        public BuildingsController(IBuildingsServices buildingsServices,
            ILogger<BuildingsController> logger,
            PermissionService permissionService)
        {
            _buildingsServices = buildingsServices;
            _logger = logger;
            _permissionService = permissionService;
        }
        [HttpGet(BaseUrl)]
        public async  Task<IActionResult> Index()
        {
            try
            {
                List<Buildings> buildings = await _buildingsServices.GetAll();
                return Ok(buildings);
            }
            catch(Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500,x);
            }
        }
        [HttpGet(BaseUrl+"/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Buildings buildings = await _buildingsServices.GetById(id);
                return Ok(buildings);
            }
             catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, x);
            }
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> Create([FromBody]Buildings buildings)
        {
            try
            {
                var res = await _buildingsServices.Create(buildings);
                return Ok(res);
            }
             catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, x);
            }
        }
        [HttpPost(BaseUrl+"/Update")]
        public async Task<IActionResult> Update([FromBody]Buildings buildings)
        {
            try
            {
                var res = await _buildingsServices.Update(buildings);
                return Ok(res);
            }
             catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, x);
            }
        }
    }
}
