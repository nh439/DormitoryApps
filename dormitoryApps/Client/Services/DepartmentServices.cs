using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class DepartmentServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DepartmentServices> _logger;
        private readonly SessionServices _sessionServices;
        public const string ControllerName = "api/department";
        public DepartmentServices(HttpClient httpClient,
            ILogger<DepartmentServices> logger, SessionServices sessionServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionServices = sessionServices;
        }
        public async Task<List<Department>?> Getdepartments()
        {
            try
            {
                var res = await _sessionServices.Permissioncheck();
                Console.WriteLine(res);
                if (res)
                {
                    return await _httpClient.GetFromJsonAsync<List<Department>>(ControllerName);
                }
                return new List<Department>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Department>.Select(), x);
            }
            return null;
        }
        public async Task<Department?> GetById(int Id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Department>($"{ControllerName}/{Id}");
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Department>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(Department item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync<Department>($"{ControllerName}/Create", item);
                return res.IsSuccessStatusCode;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Department>.Insert(), x);
            }
            return false;
        }
        public async Task<bool> Update(Department item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync<Department>($"{ControllerName}/Update", item);
                return res.IsSuccessStatusCode;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Department>.Update(), x);
            }
            return false;
        }

    }
}
