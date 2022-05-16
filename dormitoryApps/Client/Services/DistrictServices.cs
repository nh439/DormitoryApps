using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.location;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class DistrictServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DepartmentServices> _logger;
        public const string ControllerName = "api/Districts";

        public DistrictServices(HttpClient httpClient, ILogger<DepartmentServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task< List<Districts>?> Getall()
        {
            try
            {
                var districts = await _httpClient.GetFromJsonAsync<List<Districts>>(ControllerName);
                return districts;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Districts>.Select(), x);
            }
            return null;
        }
        public async Task<List<Districts>?> GetByProvince(string province)
        {
            try
            {
                var districts = await _httpClient.GetFromJsonAsync<List<Districts>>($"{ControllerName}/{province}");
                return districts;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Districts>.Select(), x);
            }
            return null;
        }
        public async Task<string[]?> Getprovince()
        {
            try
            {
                var provinces = await _httpClient.GetFromJsonAsync<string[]>($"{ControllerName}/Get");
                return provinces;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Districts>.Select(), x);
            }
            return null;
        }
        public async Task<string[]?> GetDistricts(string province)
        {
            try
            {
                var districts = await _httpClient.GetFromJsonAsync<string[]>($"{ControllerName}/Get?province={province}");
                return districts;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Districts>.Select(), x);
            }
            return null;
        }
        public async Task<string[]?> GetSubDistricts(string province,string district)
        {
            try
            {
                var subdistricts = await _httpClient.GetFromJsonAsync<string[]>($"{ControllerName}/Get?province={province}&district={district}");
                return subdistricts;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Districts>.Select(), x);
            }
            return null;
        }
        public async Task<int?> GetPostalCode(string province, string district,string subdistrict)
        {
            try
            {
                var postal = await _httpClient.GetFromJsonAsync<int>($"{ControllerName}/Get?province={province}&district={district}&subdistrict={subdistrict}");
                return postal;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Districts>.Select(), x);
            }
            return 0;
        }

    }
}
