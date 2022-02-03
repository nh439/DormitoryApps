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
        public const string ControllerName = "api/Electricity";

        public InvoiceServices(HttpClient httpClient, SessionServices sessionServices, ILogger<InvoiceServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<Invoice>?> GetInvoices()
        {
            await _sessionServices.RequiredPermission();
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>(ControllerName);
            return invoices;
        }
        public async Task<List<Invoice>?> GetByYear(int year)
        {
            await _sessionServices.RequiredPermission();
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?year={year}");
            return invoices;
        }
        public async Task<List<Invoice>?> GetByMonth(int month, int year)
        {
            await _sessionServices.RequiredPermission();
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}?year={year}&month={month}");
            return invoices;
        }
        public async Task<List<Invoice>?> GetByRental(string RentalId)
        {
            await _sessionServices.RequiredPermission();
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}/rental/{RentalId}");
            return invoices;
        }
        public async Task<Invoice?> GetById(long Id)
        {
            await _sessionServices.RequiredPermission();
            Invoice? invoices = await _httpClient.GetFromJsonAsync<Invoice>($"{ControllerName}/Id/{Id}");
            return invoices;
        }
        public async Task<List<Invoice>?> GetPaid()
        {
            await _sessionServices.RequiredPermission();
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}/Paid");
            return invoices;
        }
        public async Task<List<Invoice>?> GetUnPaid()
        {
            await _sessionServices.RequiredPermission();
            List<Invoice>? invoices = await _httpClient.GetFromJsonAsync<List<Invoice>>($"{ControllerName}/UnPaid");
            return invoices;
        }
        public async Task<List<Invoice>?> GetWithAdvancesearch(InvoiceAdvancedSearchCriteria criteria)
        {
            await _sessionServices.RequiredPermission();
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


    }
}
