using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class RoomFurnHeaderServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RoomFurnHeaderServices> _logger;
        public const string ControllerName = "api/RoomFurnHeader";

        public RoomFurnHeaderServices(HttpClient httpClient, ILogger<RoomFurnHeaderServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<List<RoomFurnHeader>> GetallHeaders()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomFurnHeader>>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeader>.Select(), x);
            }
            return null;
        }
        public async Task<List<RoomFurnHeader>> GetByType(string type)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomFurnHeader>>($"{ControllerName}/Type/{type}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeader>.Select(), x);
            }
            return null;
        }
        public async Task<List<RoomFurnHeader>> GetContain(string keyword)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomFurnHeader>>($"{ControllerName}/Contains/{keyword}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeader>.Select(), x);
            }
            return null;
        }
        public async Task<RoomFurnHeader> GetById(long Id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<RoomFurnHeader>($"{ControllerName}?Id={Id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeader>.Select(), x);
            }
            return null;
        }

        public async Task<string[]> GetTypes()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<string[]>($"{ControllerName}/Type");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeader>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(RoomFurnHeader item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeader>.Insert(), x);
            }
            return false;
        }
        public async Task<int> Create(IEnumerable<RoomFurnHeader> items)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", items);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeader>.Insert(), x);
            }
            return -1;
        }

        public async Task<bool> Update(RoomFurnHeader item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeader>.Update(), x);
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
                _logger.LogError(ServiceException<RoomFurnHeader>.Delete(), x);
            }
            return false;
        }
        public async Task<int> DeleteByType(string itemType)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/DeleteByType", itemType);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeader>.Delete(), x);
            }
            return -1;
        }

    }
} 
