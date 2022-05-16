using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class RoomfurnTemplateServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<RoomfurnTemplateServices> _logger;
        public const string ControllerName = "api/RoomfurnTemplate";

        public RoomfurnTemplateServices(HttpClient httpClient, SessionServices sessionServices, ILogger<RoomfurnTemplateServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<RoomfurnTemplate>> Get()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomfurnTemplate>>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<RoomfurnTemplate> Get(long Id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<RoomfurnTemplate>($"{ControllerName}?Id={Id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<List<RoomfurnTemplate>> GetByType(string typeName)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomfurnTemplate>>($"{ControllerName}/Type/{typeName}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<List<RoomfurnTemplate>> GetByTemplate(int templateId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomfurnTemplate>>($"{ControllerName}/Template/{templateId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(RoomfurnTemplate template)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", template);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Insert(), x);
            }
            return false;
        }
        public async Task<int> Create(IEnumerable<RoomfurnTemplate> templates)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", templates);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Insert(), x);
            }
            return -1;
        }
        public async Task<bool> Update(RoomfurnTemplate template)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", template);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Update(), x);
            }
            return false;
        }
        public async Task<bool> Delete(long itemId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", itemId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Delete(), x);
            }
            return false;
        }
        public async Task<int> DeleteTemplate(int roomId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/DeleteTemplate", roomId);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Delete(), x);
            }
            return -1;
        }

    }
}
