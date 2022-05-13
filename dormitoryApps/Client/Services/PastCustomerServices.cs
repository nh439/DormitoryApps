using Blazored.SessionStorage;
using dormitoryApps.Client.Enum;
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
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.GetFromJsonAsync<List<PastCustomer>>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PastCustomer>.Select(), x);
            }
            return null;
        }
        public async Task<List<PastCustomer>> GetPastCustomers(int page)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.GetFromJsonAsync<List<PastCustomer>>($"{ControllerName}?page={page}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PastCustomer>.Select(), x);
            }
            return null;
        }

        public async Task<List<PastCustomer>> GetUnRefund()
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.GetFromJsonAsync<List<PastCustomer>>($"{ControllerName}/GetUnRefund");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PastCustomer>.Select(), x);
            }
            return null;
        }
        public async Task<PastCustomer> GetById(string Id)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.GetFromJsonAsync<PastCustomer>($"{ControllerName}/Id/{Id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PastCustomer>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(PastCustomer entity)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", entity);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PastCustomer>.Insert(), x);
            }
            return false;
        }
         public async Task<bool> Create(IEnumerable<PastCustomer> entities)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", entities);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PastCustomer>.Insert(), x);
            }
            return false;
        }
         public async Task<bool> Update(PastCustomer entity)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", entity);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PastCustomer>.Update(), x);
            }
            return false;
        }
         public async Task<bool> Delete(string Id)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", Id);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PastCustomer>.Delete(), x);
            }
            return false;
        }
        public async Task<string[]> GetIdList()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<string[]>($"{ControllerName}/Idlist");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PastCustomer>.Select(), x);
            }
            return null;
        }


    }
}
