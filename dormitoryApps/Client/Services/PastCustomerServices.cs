using Blazored.SessionStorage;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class PastCustomerServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PastCustomerServices> _logger;
        private readonly ISessionStorageService _sessionStorageService;
        private readonly SessionServices _sessionServices;
        public const string ControllerName = "api/PastCustomer";
        public PastCustomerServices(HttpClient httpClient,
            ILogger<PastCustomerServices> logger,
            ISessionStorageService sessionStorageService,
            SessionServices sessionServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionStorageService = sessionStorageService;
            _sessionServices = sessionServices;
        }
        public async Task<List<PastCustomer>> GetPastCustomers()
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.GetFromJsonAsync<List<PastCustomer>>(ControllerName);
            return res;
        }
        public async Task<List<PastCustomer>> GetPastCustomers(int page)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.GetFromJsonAsync<List<PastCustomer>>($"{ControllerName}?page={page}");
            return res;
        }

        public async Task<List<PastCustomer>> GetUnRefund()
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.GetFromJsonAsync<List<PastCustomer>>($"{ControllerName}/GetUnRefund");
            return res;
        }
        public async Task<PastCustomer> GetById(string Id)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.GetFromJsonAsync<PastCustomer>($"{ControllerName}//Id/{Id}");
            return res;
        }
        public async Task<bool> Create(PastCustomer entity)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", entity);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
         public async Task<bool> Create(IEnumerable<PastCustomer> entities)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", entities);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
         public async Task<bool> Update(PastCustomer entity)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", entity);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
         public async Task<bool> Delete(string Id)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", Id);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<string[]> GetIdList()
        {
            var res = await _httpClient.GetFromJsonAsync<string[]>($"{ControllerName}/Idlist");
            return res;
        }


    }
}
