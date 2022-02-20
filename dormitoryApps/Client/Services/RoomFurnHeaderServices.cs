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
            var res = await _httpClient.GetFromJsonAsync<List<RoomFurnHeader>>(ControllerName);
            return res;
        }
        public async Task<List<RoomFurnHeader>> GetByType(string type)
        {
            var res = await _httpClient.GetFromJsonAsync<List<RoomFurnHeader>>($"{ControllerName}/Type/{type}");
            return res;
        }
        public async Task<RoomFurnHeader> GetById(long Id)
        {
            var res = await _httpClient.GetFromJsonAsync<RoomFurnHeader>($"{ControllerName}?Id={Id}");
            return res;
        }

        public async Task<string[]> GetTypes()
        {
            var res = await _httpClient.GetFromJsonAsync<string[]>($"{ControllerName}/Type");
            return res;
        }
        public async Task<bool> Create(RoomFurnHeader item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<int> Create(IEnumerable<RoomFurnHeader> items)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", items);
            return await res.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> Update(RoomFurnHeader item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete(long itemId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", itemId);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> DeleteByType(string itemType)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/DeleteByType", itemType);
            return await res.Content.ReadFromJsonAsync<bool>();
        }

    }
} 
