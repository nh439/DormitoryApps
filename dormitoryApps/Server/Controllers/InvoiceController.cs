using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace dormitoryApps.Server.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceServices _invoiceServices;
        private readonly ILogger<InvoiceController> _logger;
        private const string BaseUrl = "/api/Invoice";

        public InvoiceController(IInvoiceServices invoiceServices, ILogger<InvoiceController> logger)
        {
            _invoiceServices = invoiceServices;
            _logger = logger;
        }
        [HttpGet(BaseUrl)]
        public async Task< IActionResult> Index(int? year,int? month,int? page,string filter)
        {
            List<Invoice> invoices;
            try
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    invoices = await _invoiceServices.GetContains(filter);
                    if (year.HasValue)
                    {
                        invoices = invoices.Where(x => x.Year == year.Value).ToList();
                        if (month.HasValue)
                        {
                            invoices = invoices.Where(x => x.Month == month.Value).ToList();
                        }
                    }
                }
                else
                {
                    if (year.HasValue)
                    {
                        if (month.HasValue)
                        {
                            invoices = await _invoiceServices.GetByMonth(Month: month.Value, year: year.Value);
                        }
                        else
                        {
                            invoices = await _invoiceServices.GetByYear(year.Value);
                        }
                    }
                    else
                    {
                        invoices = await _invoiceServices.GetAll();
                    }
                }
                if (page.HasValue)
                {
                    return Ok(invoices.OrderByDescending(x => x.InvoiceDate).OrderBy(x => x.Ispaid).OrderBy(x => x.Iscancel).ToPagedList(page.Value, 20));
                }
                return Ok(invoices);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/rental/{rentalId}")]
        public async Task<IActionResult> GetByRental(string rentalId)
        {
            try
            {
                var res = await _invoiceServices.GetByRental(rentalId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/Id/{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            try
            {
                var res = await _invoiceServices.GetById(Id);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet($"{BaseUrl}/Paid")]
        public async Task<IActionResult> GetPaid()
        {
            try
            {
                var res = await _invoiceServices.GetPaid();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpGet($"{BaseUrl}/UnPaid")]
        public async Task<IActionResult> GetUnPaid()
        {
            try
            {
                var res = await _invoiceServices.GetUnPaid();
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost($"{BaseUrl}/Create")]
        public async Task<IActionResult> Create([FromBody] Invoice item)
        {
            try
            {
                var res = await _invoiceServices.Create(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost($"{BaseUrl}/Update")]
        public async Task<IActionResult> Update([FromBody] Invoice item)
        {
            try
            {
                var res = await _invoiceServices.Update(item);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost($"{BaseUrl}/Delete")]
        public async Task<IActionResult> Delete([FromBody]string InvoiceId)
        {
            try
            {
                var res = await _invoiceServices.Delete(InvoiceId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult>  GetWithAdvancesearch([FromBody]InvoiceAdvancedSearchCriteria criteria)
        {
            try
            {
                var res = await _invoiceServices.GetWithAdvancesearch(criteria);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/{page}")]
        public async Task<IActionResult> GetWithAdvancesearch(int page,[FromBody] InvoiceAdvancedSearchCriteria criteria)
        {
            try
            {
                var res = await _invoiceServices.GetWithAdvancesearch(criteria);
                res = res.OrderByDescending(x => x.Id).OrderBy(x => x.Ispaid).OrderBy(x => x.Iscancel).ToList();
                return Ok(res.ToPagedList(page, 20));
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return StatusCode(500, "Something Went Wrong");
            }
        }


    }
}
