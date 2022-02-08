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
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<MyServices>>(ControllerName);
                return res;
            }
            catch(Exception x)
            {
                _logger.LogError("GetMyservices",x);               
            }
            return new List<MyServices>();
        }
        public async Task<MyServices> GetById(long Id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<MyServices>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError("GetMyservices", x);
            }
            return new MyServices();
        }
        public async Task<bool> Create(MyServices entity)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", entity);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError("GetMyservices", x);
                return false;
            }
        }
        public async Task<bool> Update(MyServices entity)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", entity);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError("GetMyservices", x);
                return false;
            }
        }
        public async Task<bool> Delete(long itemId)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", itemId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError("GetMyservices", x);
                return false;
            }
        }

    }
}
