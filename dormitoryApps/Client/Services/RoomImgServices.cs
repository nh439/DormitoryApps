using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class RoomImgServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<RoomImgServices> _logger;
        public const string ControllerName = "api/RoomImg";

        public RoomImgServices(HttpClient httpClient, SessionServices sessionServices, ILogger<RoomImgServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<RoomImg> GetByRoom(int roomId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<RoomImg>($"{ControllerName}/{roomId}");
                return res;
            }
            catch(Exception x)
            {
                _logger.LogError(x.Message, x);
                return null;
            }
        }
        public async Task<RoomImg> GetById(long Id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<RoomImg>($"{ControllerName}/Id/{Id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return null;
            }
        }
        public async Task<bool> Create(RoomImg item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return false;
            }
        }
        public async Task<bool> Update(RoomImg item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return false;
            }
        }
        public async Task<bool> UpdateCommit(IEnumerable<RoomImg> items)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/UpdateCommit", items);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return false;
            }
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
                _logger.LogError(x.Message, x);
                return false;
            }
        }

        public async Task<int> DeleteByRoom(int roomId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/DeleteByRoom", roomId);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(x.Message, x);
                return -1;
            }
        }

    }
}
