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
        public async Task< IActionResult> Index(int? year,int? month,int? page)
        {
            List<Invoice> invoices;
            if (year.HasValue)
            {
                if (month.HasValue)
                {
                    invoices = await _invoiceServices.GetByMonth(Month: month.Value, year: year.Value);
                }
                invoices = await _invoiceServices.GetByYear(year.Value);
            }
            else
            {
                invoices = await _invoiceServices.GetAll();
            }
            if(page.HasValue)
            {
                return Ok(invoices.OrderByDescending(x=>x.InvoiceDate).ToPagedList(page.Value, 20));
            }
            return Ok(invoices);
        }
        [HttpGet(BaseUrl+"/rental/{rentalId}")]
        public async Task<IActionResult> GetByRental(string rentalId)
        {
            var res = await _invoiceServices.GetByRental(rentalId);
            return Ok(res);
        }
        [HttpGet(BaseUrl+"/Id/{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            var res = await _invoiceServices.GetById(Id);
            return Ok(res);
        }
        [HttpGet($"{BaseUrl}/Paid")]
        public async Task<IActionResult> GetPaid()
        {
            var res = await _invoiceServices.GetPaid();
            return Ok(res);
        }
        [HttpGet($"{BaseUrl}/UnPaid")]
        public async Task<IActionResult> GetUnPaid()
        {
            var res = await _invoiceServices.GetUnPaid();
            return Ok(res);
        }
        [HttpPost($"{BaseUrl}/Create")]
        public async Task<IActionResult> Create([FromBody] Invoice item)
        {
            var res = await _invoiceServices.Create(item);
            return Ok(res);
        }
        [HttpPost($"{BaseUrl}/Update")]
        public async Task<IActionResult> Update([FromBody] Invoice item)
        {
            var res = await _invoiceServices.Update(item);
            return Ok(res);
        }
        [HttpPost($"{BaseUrl}/Delete")]
        public async Task<IActionResult> Delete([FromBody]string InvoiceId)
        {
            var res = await _invoiceServices.Delete(InvoiceId);
            return Ok(res);
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult>  GetWithAdvancesearch([FromBody]InvoiceAdvancedSearchCriteria criteria)
        {
            var res = await _invoiceServices.GetWithAdvancesearch(criteria);
            return Ok(res);
        }


    }
}
