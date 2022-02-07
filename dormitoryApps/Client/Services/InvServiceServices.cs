using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class InvServiceServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<InvoiceServices> _logger;
        public const string ControllerName = "api/InvoiceService";

        public InvServiceServices(HttpClient httpClient, SessionServices sessionServices, ILogger<InvoiceServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<InvoiceServices>> GetByInvoice(string invoiceId)
        {
            var havePermission =await  _sessionServices.Permissioncheck();
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<InvoiceServices>>($"{ControllerName}/Invoice/{invoiceId}");
                return res;
            }
            return new List<InvoiceServices>();
        }
        public async Task<List<InvoiceServices>> GetByServices(long serviceId)
        {
            var havePermission =await  _sessionServices.Permissioncheck();
            if (havePermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<InvoiceServices>>($"{ControllerName}/Service/{serviceId}");
                return res;
            }
            return new List<InvoiceServices>();
        }
        public async Task<bool> Create(InvoiceServices item)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<int> Create(IEnumerable< InvoiceServices> items)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", items);
            return await res.Content.ReadFromJsonAsync<int>();
        }
        public async Task<bool> Update(InvoiceServices item)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete(InvoiceServices item)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
    }
}
