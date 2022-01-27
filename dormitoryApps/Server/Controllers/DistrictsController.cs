using dormitoryApps.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class DistrictsController : Controller
    {
        private readonly IDistrictsServices _districtsServices;
        private readonly ILogger<DistrictsController> _logger;
        private const string BaseUrl = "/api/Districts";
        public DistrictsController(IDistrictsServices districtsServices, ILogger<DistrictsController> logger)
        {
            _districtsServices = districtsServices;
            _logger = logger;
        }
        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index()
        {
            try
            {
                var res = await _districtsServices.Getall();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Insert Incomplete");
            }
        }
        [HttpGet(BaseUrl+"/{province}")]
        public async Task<IActionResult> GetByprovince(string province)
        {
            try
            {
                var res = await _districtsServices.GetByProvince(province);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Insert Incomplete");
            }
        }
        [HttpGet($"{BaseUrl}/Get")]
        public async Task<IActionResult> Getlist(string? province,string? district,string? subdistrict)
        {
            try
            {
                if (!string.IsNullOrEmpty(province) && !string.IsNullOrEmpty(district) && !string.IsNullOrEmpty(subdistrict))
                {
                    var res1 = await _districtsServices.GetPostalCode(province, district, subdistrict);
                    return Ok(res1);
                }
                else if (!string.IsNullOrEmpty(province) && !string.IsNullOrEmpty(district))
                {
                    var res2 = await _districtsServices.GetSubdistricts(province, district);
                    return Ok(res2);
                }
                else if (!string.IsNullOrEmpty(province))
                {
                    var res3 = await _districtsServices.Getdistricts(province);
                    return Ok(res3);
                }
                var res = await _districtsServices.GetProvince();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Insert Incomplete");
            }

        }

    }
}
