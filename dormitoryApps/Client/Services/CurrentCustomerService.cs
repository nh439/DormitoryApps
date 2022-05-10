using dormitoryApps.Client.Enum;
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
            try
            {
                var havepermission = true;
                if (!havepermission)
                {
                    return new List<CurrentCustomer>();
                }
                var result = await _httpClient.GetFromJsonAsync<List<CurrentCustomer>>(ControllerName);
                return result;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<CurrentCustomer>.Select(), x);
            }
            return null;
        }
         public async Task<List<CurrentCustomer>> Get(int page)
        {
            try
            {
                var havepermission = true;
                if (!havepermission)
                {
                    return new List<CurrentCustomer>();
                }
                var result = await _httpClient.GetFromJsonAsync<List<CurrentCustomer>>($"{ControllerName}?page={page}");
                return result;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<CurrentCustomer>.Select(), x);
            }
            return null;
        }

        public async Task<CurrentCustomer> Get(string Id)
        {
            try
            {
                var havepermission = true;
                if (!havepermission)
                {
                    return new CurrentCustomer();
                }
                var result = await _httpClient.GetFromJsonAsync<CurrentCustomer>($"{ControllerName}/{Id}");
                return result;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<CurrentCustomer>.Select(), x);
            }
            return null;
        }
        public async Task<List<CurrentCustomer>> GetByRoom(int Id)
        {
            try
            {
                var havepermission = true;
                if (!havepermission)
                {
                    return new List<CurrentCustomer>();
                }
                var result = await _httpClient.GetFromJsonAsync<List<CurrentCustomer>>($"{ControllerName}/Room/{Id}");
                return result;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<CurrentCustomer>.Select(), x);
            }
            return null; 
        }
        public async Task<string?> Create(CurrentCustomer customer)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var result = await _httpClient.PostAsJsonAsync(ControllerName, customer);
                return await result.Content.ReadAsStringAsync();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<CurrentCustomer>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Update(CurrentCustomer customer)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var result = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", customer);
                return await result.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<CurrentCustomer>.Select(), x);
            }
            return false;
        }
        public async Task<bool> Delete(string Id)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var result = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", Id);
                return await result.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<CurrentCustomer>.Select(), x);
            }
            return false;
        }

        public async Task<string[]> GetIdList()
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var result = await _httpClient.GetFromJsonAsync<string[]>($"{ControllerName}/idlist");
                return result;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<CurrentCustomer>.Select(), x);
            }
            return new string[0];
        }
    }
}
