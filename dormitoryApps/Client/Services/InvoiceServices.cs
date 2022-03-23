using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class InvoiceServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<InvoiceServices> _logger;
        public const string ControllerName = "api/Invoice";

        public InvoiceServices(HttpClient httpClient, SessionServices sessionServices, ILogger<InvoiceServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<Invoice>?> GetInvoices()
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if(!Havepermission)
            {
                return new List<Invoice>();
            }
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>(ControllerName);
            return invoices;
        }
        public async Task<List<Invoice>?> GetByYear(int year)
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if (!Havepermission)
            {
                return new List<Invoice>();
            }
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?year={year}");
            return invoices;
        }
        public async Task<List<Invoice>?> GetByMonth(int month, int year)
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if (!Havepermission)
            {
                return new List<Invoice>();
            }
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?year={year}&month={month}");
            return invoices;
        }
        public async Task<List<Invoice>?> GetByPage(int page)
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if (!Havepermission)
            {
                return new List<Invoice>();
            }
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?page={page}");
            return invoices;
        }
        public async Task<List<Invoice>?> GetByPage(int page,int year)
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if (!Havepermission)
            {
                return new List<Invoice>();
            }
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?page={page}&year={year}");
            return invoices;
        }
        public async Task<List<Invoice>?> GetByPage(int page,int year,int month)
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if (!Havepermission)
            {
                return new List<Invoice>();
            }
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?page={page}&year={year}&month={month}");
            return invoices;
        }

        public async Task<List<Invoice>?> GetByRental(string RentalId)
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if (!Havepermission)
            {
                return new List<Invoice>();
            }
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}/rental/{RentalId}");
            return invoices;
        }
        public async Task<Invoice?> GetById(string Id)
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if (!Havepermission)
            {
                return new Invoice();
            }
            Invoice? invoices = await _httpClient.GetFromJsonAsync<Invoice>($"{ControllerName}/Id/{Id}");
            return invoices;
        }
        public async Task<List<Invoice>?> GetPaid()
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if (!Havepermission)
            {
                return new List<Invoice>();
            }
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}/Paid");
            return invoices;
        }
        public async Task<List<Invoice>?> GetUnPaid()
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if (!Havepermission)
            {
                return new List<Invoice>();
            }
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}/UnPaid");
            return invoices;
        }
        public async Task<List<Invoice>?> GetWithAdvancesearch(InvoiceAdvancedSearchCriteria criteria)
        {
            var Havepermission = await _sessionServices.Permissioncheck();
            if (!Havepermission)
            {
                return new List<Invoice>();
            }
            var res = await _httpClient.PostAsJsonAsync(ControllerName, criteria);
            return await res.Content.ReadFromJsonAsync<List<Invoice>>();
        }
        public async Task<bool> Create(Invoice invoice)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", invoice);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
         public async Task<bool> Update(Invoice invoice)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", invoice);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
         public async Task<bool> Delete(long invoiceId)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", invoiceId);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public Invoice InvoiceCalculate(Invoice invoice)
        {
            var serviceprice = (invoice.Services != null ? invoice.Services.Select(x => x.Price).Sum() : 0);
            var waterprice = (invoice.Water != null ? invoice.Water.Price : 0);
            var electricityprice = (invoice.Electricity != null ? invoice.Electricity.Price : 0);
            invoice.GrandTotal = serviceprice+waterprice + electricityprice+invoice.RentalPrice+invoice.Fee-(invoice.Discount.HasValue ? invoice.Discount.Value:0);
            invoice.ServicePrice = serviceprice;
            return invoice;
        }
        public Invoice InvoiceCalculate(Invoice invoice,decimal taxpercentage)
        {
            var serviceprice = (invoice.Services != null ? invoice.Services.Select(x => x.Price).Sum() : 0);
            var waterprice = (invoice.Water != null ? invoice.Water.Price : 0);
            var electricityprice = (invoice.Electricity != null ? invoice.Electricity.Price : 0);
            var total = serviceprice + waterprice + electricityprice + invoice.RentalPrice;
            invoice.Tax = (taxpercentage / 100) * total;
            invoice.GrandTotal = total+invoice.Tax;
            invoice.ServicePrice = serviceprice;
            return invoice;
        }
        public Invoice InvoiceCalculate(Invoice invoice, decimal taxpercentage,decimal charge)
        {
            var serviceprice = (invoice.Services != null ? invoice.Services.Select(x => x.Price).Sum() : 0);
            var waterprice = (invoice.Water != null ? invoice.Water.Price : 0);
            var electricityprice = (invoice.Electricity != null ? invoice.Electricity.Price : 0);
            var total = serviceprice + waterprice + electricityprice + invoice.RentalPrice+charge;
            invoice.Tax = (taxpercentage / 100) * total;
            invoice.GrandTotal = total + invoice.Tax;
            invoice.ServicePrice = serviceprice;
            return invoice;
        }
        public Invoice InvoiceCalculate(Invoice invoice, decimal taxpercentage,decimal charge,decimal discount)
        {
            var serviceprice = (invoice.Services != null ? invoice.Services.Select(x => x.Price).Sum() : 0);
            var waterprice = (invoice.Water != null ? invoice.Water.Price : 0);
            var electricityprice = (invoice.Electricity != null ? invoice.Electricity.Price : 0);
            var total = (serviceprice + waterprice + electricityprice + invoice.RentalPrice+charge)-discount;
            invoice.Tax = (taxpercentage / 100) * total;
            invoice.GrandTotal = total + invoice.Tax;
            invoice.ServicePrice = serviceprice;
            return invoice;
        }


    }
}
