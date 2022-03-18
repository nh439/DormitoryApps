using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class CurrentCustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DepartmentServices> _logger;
        private readonly SessionServices _sessionServices;
        public const string ControllerName = "api/currentcustomer";
        public CurrentCustomerService(HttpClient httpClient, 
            ILogger<DepartmentServices> logger,
            SessionServices sessionServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionServices = sessionServices;
        }
        public async Task<List<CurrentCustomer>> Get()
        {
            var havepermission = await _sessionServices.Permissioncheck();
            if(!havepermission)
            {
                return new List<CurrentCustomer>();
            }
            var result = await _httpClient.GetFromJsonAsync<List<CurrentCustomer>>(ControllerName);
            return result;
        }
         public async Task<List<CurrentCustomer>> Get(int page)
        {
            var havepermission = await _sessionServices.Permissioncheck();
            if(!havepermission)
            {
                return new List<CurrentCustomer>();
            }
            var result = await _httpClient.GetFromJsonAsync<List<CurrentCustomer>>($"{ControllerName}?page={page}");
            return result;
        }

        public async Task<List<CurrentCustomer>> Get(string Id)
        {
            var havepermission = await _sessionServices.Permissioncheck();
            if (!havepermission)
            {
                return new List<CurrentCustomer>();
            }
            var result = await _httpClient.GetFromJsonAsync<List<CurrentCustomer>>($"{ControllerName}/{Id}");
            return result;
        }
        public async Task<List<CurrentCustomer>> GetByRoom(int Id)
        {
            var havepermission = await _sessionServices.Permissioncheck();
            if (!havepermission)
            {
                return new List<CurrentCustomer>();
            }
            var result = await _httpClient.GetFromJsonAsync<List<CurrentCustomer>>($"{ControllerName}/Room/{Id}");
            return result;
        }
        public async Task<string?> Create(CurrentCustomer customer)
        {
            await _sessionServices.RequiredPermission();
            var result = await _httpClient.PostAsJsonAsync(ControllerName, customer);
            return await result.Content.ReadAsStringAsync();
        }
        public async Task<bool> Update(CurrentCustomer customer)
        {
            await _sessionServices.RequiredPermission();
            var result = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", customer);
            return await result.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete(string Id)
        {
            await _sessionServices.RequiredPermission();
            var result = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", Id);
            return await result.Content.ReadFromJsonAsync<bool>();
        }




    }
}
