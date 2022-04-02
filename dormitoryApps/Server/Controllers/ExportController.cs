using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Export;
using Microsoft.AspNetCore.Mvc;


namespace dormitoryApps.Server.Controllers
{
    public class ExportController : Controller
    {
        const string BaseUrl = "/Export";
        private readonly IInvoiceServices _invoiceServices;
        private readonly IOfficerServices _iofficerServices;
        private readonly ICurrentCustomerServices _currentCustomerServices;
        private readonly IPastCustomerServices _pastCustomerServices;
        private readonly ISessionServices _sessionServices;
        private readonly IHttpContextAccessor _accessor;

        public ExportController(IInvoiceServices invoiceServices,
            IOfficerServices iofficerServices,
            ICurrentCustomerServices currentCustomerServices,
            IPastCustomerServices pastCustomerServices,
            ISessionServices sessionServices,
            IHttpContextAccessor accessor)
        {
            _invoiceServices = invoiceServices;
            _iofficerServices = iofficerServices;
            _currentCustomerServices = currentCustomerServices;
            _pastCustomerServices = pastCustomerServices;
            _sessionServices = sessionServices;
            _accessor = accessor;

        }


        [HttpGet(BaseUrl+ "/Invoice/{id}")]
        public async Task<IActionResult> ExportInvoice(string id)
        {
            bool exportfailed = false;
            InvoiceExport export = new InvoiceExport() { InvoiceId=id};
            await _invoiceServices.GetById(export.InvoiceId).ContinueWith(x =>
            {
                if (x.Result != null)
                {
                    export.Invoice = x.Result;
                }
                exportfailed = x.Result == null;

            });
            if (exportfailed || string.IsNullOrEmpty(_accessor.HttpContext.Session.GetString("Id"))) return Redirect("/Error");
            export.Customers = await _currentCustomerServices.GetById(export.Invoice.RentalId);
            if (export.Customers == null) export.PastCustomer = await _pastCustomerServices.GetById(export.Invoice.RentalId);
            export.InvoiceOfficer = await _iofficerServices.GetById(export.Invoice.InvoiceOfficer);
            if(export.Invoice.Ispaid) export.PaidOfficer = await _iofficerServices.GetById(export.Invoice.PaidOfficer.GetValueOrDefault());
            await _sessionServices.GetCurrentlogin(_accessor.HttpContext.Session.GetString("Id")).ContinueWith(x =>
            {
                export.ExportedOfficer = x.Result;
            });
            await Task.Delay(10);
            return View(export);
        }
        [HttpGet(BaseUrl+"/Error")]
        public IActionResult ExportFailed()
        {
            return Ok("Export Failed");
        }
    }
}
