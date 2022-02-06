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
        public async Task<List<RoomImg>> GetByRoom(int roomId)
        {
            var res = await _httpClient.GetFromJsonAsync<List<RoomImg>>($"{ControllerName}/{roomId}");
            return res;
        }
        public async Task<RoomImg> GetById(long Id)
        {
            var res = await _httpClient.GetFromJsonAsync<RoomImg>($"{ControllerName}/Id/{Id}");
            return res;
        }
        public async Task<bool> Create(RoomImg item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Update(RoomImg item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> UpdateCommit(IEnumerable<RoomImg> items)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/UpdateCommit", items);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete(long itemId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", itemId);
            return await res.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<int> DeleteByRoom(int roomId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/DeleteByRoom", roomId);
            return await res.Content.ReadFromJsonAsync<int>();
        }

    }
}
