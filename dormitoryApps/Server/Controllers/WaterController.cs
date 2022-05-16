using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace dormitoryApps.Server.Controllers
{
    public class WaterController : Controller
    {
        private readonly IWaterServices _waterServices;
        private readonly ILogger<WaterController> _logger;
        private const string BaseUrl = "/api/Water";
        public WaterController(IWaterServices waterServices, ILogger<WaterController> logger)
        {
            _waterServices = waterServices;
            _logger = logger;
        }
        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(string? RentalId, int? Year, int? Month,int? page)
        {
            try
            {
                List<Water> result = new List<Water>();
                if (Year.HasValue)
                {
                    if (Month.HasValue)
                    {
                        if (!string.IsNullOrEmpty(RentalId))
                        {
                            return Ok(await _waterServices.Getone(RentalId, Month.Value, Year.GetValueOrDefault()));
                        }
                        result = await _waterServices.GetByMonth(month: Month.GetValueOrDefault(), year: Year.GetValueOrDefault());
                    }
                    result = await _waterServices.GetByYear(year: Year.GetValueOrDefault());
                }
                result = await _waterServices.Getall();
                if (page.HasValue)
                {
                    return Ok(result.ToPagedList(page.Value, 20));
                }
                return Ok(result);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl + "/Rental/{Id}")]
        public async Task<IActionResult> GetRental(string Id)
        {
            try
            {
                var res = await _waterServices.GetByRentalId(Id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl + "/Paid")]
        public async Task<IActionResult> Getpaid()
        {
            try
            {
                var res = await _waterServices.GetPaid();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl + "/UnPaid")]
        public async Task<IActionResult> GetUnpaid()
        {
            try
            {
                var res = await _waterServices.GetUnPaid();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> AdvancedSearch([FromBody] ElectricityAndWaterAdvancedSearchCriteria criteria)
        {
            try
            {
                var res = await _waterServices.GetWithAdvanceSearch(criteria);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Create")]
        public async Task<IActionResult> Create([FromBody] Water item)
        {
            try
            {
                var res = await _waterServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody] Water item)
        {
            try
            {
                var res = await _waterServices.Update(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody] Water item)
        {
            try
            {
                var res = await _waterServices.Delete(rentalId: item.RentalId, month: item.month, year: item.Year);
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
