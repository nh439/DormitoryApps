using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Index(string? RentalId, int? Year, int? Month)
        {
            if (Year.HasValue)
            {
                if (Month.HasValue)
                {
                    if (!string.IsNullOrEmpty(RentalId))
                    {
                        return Ok(await _waterServices.Getone(RentalId, Month.Value, Year.GetValueOrDefault()));
                    }
                    return Ok(await _waterServices.GetByMonth(month: Month.GetValueOrDefault(), year: Year.GetValueOrDefault()));
                }
                return Ok(await _waterServices.GetByYear(year: Year.GetValueOrDefault()));
            }
            var res = await _waterServices.Getall();
            return Ok(res);
        }
        [HttpGet(BaseUrl + "/Rental/{Id}")]
        public async Task<IActionResult> GetRental(string Id)
        {
            var res = await _waterServices.GetByRentalId(Id);
            return Ok(res);
        }
        [HttpGet(BaseUrl + "/Paid")]
        public async Task<IActionResult> Getpaid()
        {
            var res = await _waterServices.GetPaid();
            return Ok(res);
        }
        [HttpGet(BaseUrl + "/UnPaid")]
        public async Task<IActionResult> GetUnpaid()
        {
            var res = await _waterServices.GetUnPaid();
            return Ok(res);
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> AdvancedSearch([FromBody] ElectricityAndWaterAdvancedSearchCriteria criteria)
        {
            var res = await _waterServices.GetWithAdvanceSearch(criteria);
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/Create")]
        public async Task<IActionResult> Create([FromBody] Water item)
        {
            var res = await _waterServices.Create(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody] Water item)
        {
            var res = await _waterServices.Update(item);
            return Ok(res);
        }
        [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody] Water item)
        {
            var res = await _waterServices.Delete(rentalId: item.RentalId, month: item.month, year: item.Year);
            return Ok(res);
        }
    }
}
