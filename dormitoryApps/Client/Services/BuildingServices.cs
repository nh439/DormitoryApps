using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class BuildingServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DepartmentServices> _logger;
        public const string ControllerName = "api/buildings";

        public BuildingServices(HttpClient httpClient, ILogger<DepartmentServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<List<Buildings>?> Get()
        {
            try
            {
                var buildings = await _httpClient.GetFromJsonAsync<List<Buildings>>(ControllerName);
                return buildings;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Buildings>.Select(), x);
            }
            return null;
        }
        public async Task<Buildings?> Get(int id)
        {
            try
            {
                var buildings = await _httpClient.GetFromJsonAsync<Buildings>($"{ControllerName}/{id}");
                return buildings;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Buildings>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(Buildings buildings)
        {
            try
            {
                if (buildings == null)
                {
                    return false;
                }
                var res = await _httpClient.PostAsJsonAsync(ControllerName, buildings);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Buildings>.Insert(), x);
            }
            return false;
        }
        public async Task<bool> Update(Buildings buildings)
        {
            try
            {
                if (buildings == null)
                {
                    return false;
                }
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", buildings);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Buildings>.Update(), x);
            }
            return false;
        }

    }
}
