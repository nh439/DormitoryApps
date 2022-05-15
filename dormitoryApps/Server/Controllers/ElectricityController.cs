using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class ElectricityController : Controller
    {
        private readonly IElectricityServices _electricityServices;
        private readonly ILogger<ElectricityController> _logger;
        private const string BaseUrl = "/api/Electricity";

        public ElectricityController(IElectricityServices electricityServices, ILogger<ElectricityController> logger)
        {
            _electricityServices = electricityServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl)]
        public async Task<IActionResult> Index(string? RentalId, int? Year, int? Month)
        {
            try
            {
                if (Year.HasValue)
                {
                    if (Month.HasValue)
                    {
                        if (!string.IsNullOrEmpty(RentalId))
                        {
                            return Ok(await _electricityServices.Getone(RentalId, Month.Value, Year.GetValueOrDefault()));
                        }
                        return Ok(await _electricityServices.GetByMonth(month: Month.GetValueOrDefault(), year: Year.GetValueOrDefault()));
                    }
                    return Ok(await _electricityServices.GetByYear(year: Year.GetValueOrDefault()));
                }
                var res = await _electricityServices.Getall();
                return Ok(res);
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
                var res = await _electricityServices.GetByRentalId(Id);
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
                var res = await _electricityServices.GetPaid();
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
                var res = await _electricityServices.GetUnPaid();
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
                var res = await _electricityServices.GetWithAdvanceSearch(criteria);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Create")]
        public async Task<IActionResult> Create([FromBody] Electricity item)
        {
            try
            {
                var res = await _electricityServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Update")]
        public async Task<IActionResult> Update([FromBody] Electricity item)
        {
            try
            {
                var res = await _electricityServices.Update(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl + "/Delete")]
        public async Task<IActionResult> Delete([FromBody] Electricity item)
        {
            try
            {
                var res = await _electricityServices.Delete(rentalId: item.RentalId, month: item.month, year: item.Year);
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
