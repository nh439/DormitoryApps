using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Export;
using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using System.Data;
using dormitoryApps.Shared.Model.Entity;

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
            if (exportfailed || string.IsNullOrEmpty(_accessor.HttpContext.Session.GetString("Id"))) return Redirect(BaseUrl+"/Error");
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
        [HttpPost(BaseUrl+"/InvoiceExcel")]
        public async Task< IActionResult> InvoiceExcel(IEnumerable<Invoice> invoices)
        {
            List<Officer> officers = await _iofficerServices.Getall();
            DataTable invoiceTable = new DataTable("invoices");
            string[] headers = {"#",
        "รหัสใบแจ้ง",
        "รหัสการเช่า",
        "งวด",
        "ประเภทใบเสร็จ",
        "ยอดชำระ",
        "รับเงินมา",
        "ทอน",
        "ใบแจ้งค่าเช่า",
        "สถานะ",
        "วันที่ออก",
        "ออกโดย",
        "ชำระเมื่อ",
        "รับชำระโดย"};
            foreach (var header in headers)
            {
                invoiceTable.Columns.Add(header);
            }
            foreach (var invoice in invoices.OrderByDescending(x => x.InvoiceDate).Select((x, y) => new { data = x, index = y }))
            {
                var data = invoice.data;
                bool rentalMode = data.RentalPrice > 0;
                bool hasUtilty = data.Water != null || data.Electricity != null;
                bool hasService = data.IsService;
                string invoiceType = string.Empty;
                if (rentalMode) invoiceType = "ค่าเช่า";
                else if (hasUtilty) invoiceType = "ค่าสาธารณูปโภค";

                invoiceTable.Rows.Add(invoice.index,
                data.Id,
                data.RentalId,
                $"{data.Month}/{data.Year}",
                invoiceType,
                data.GrandTotal,
                data.Paid,
                data.Changes,
                data.RentalPrice > 0 ? "Yes" : "No",
                data.Ispaid ? "ชำระแล้ว" : data.Iscancel ? "ยกเลิก" : "ยังไม่ชำระ",
                data.InvoiceDate.ToString("dddd dd MMMM yyyy HH:mm:ss", new System.Globalization.CultureInfo("th-TH")),
                officers.Where(x=> x.Id ==  data.InvoiceOfficer).Select(x=> $"{x.Firstname} {x.Surname}").FirstOrDefault(),
                data.PaidDate.HasValue ? data.PaidDate.Value.ToString("dddd dd MMMM yyyy HH:mm:ss", new System.Globalization.CultureInfo("th-TH")) : "",
                data.PaidOfficer.HasValue ? officers.Where(x => x.Id == data.PaidOfficer).Select(x => $"{x.Firstname} {x.Surname}").FirstOrDefault() :""
                );
            }
            return ExportToExcel(invoiceTable);
        }

        public IActionResult ExportToExcel(DataTable table)
        {
            byte[] data;
            string filename = $"{table.TableName} {DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm:ss", new System.Globalization.CultureInfo("th-TH"))}";
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.AddWorksheet(table, table.TableName);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    data = stream.ToArray();
                }
            }
            return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"{filename}.xlsx");
        }
    }
}
