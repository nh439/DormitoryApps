using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class MyServicesServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<MyServicesServices> _logger;
        public const string ControllerName = "api/MyServices";
        
        public MyServicesServices(HttpClient httpClient,
            SessionServices sessionServices,
            ILogger<MyServicesServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<MyServices>> GetMyServices()
        {
            var res = await _httpClient.GetFromJsonAsync<List<MyServices>>(ControllerName);
            return res;
        }
        public async Task<MyServices> GetById(long Id)
        {
            var res = await _httpClient.GetFromJsonAsync<MyServices>(ControllerName);
            return res;
        }
        public async Task<bool> Create(MyServices entity)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", entity);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Update(MyServices entity)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", entity);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete(long itemId)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", itemId);
            return await res.Content.ReadFromJsonAsync<bool>();
        }

    }
}
