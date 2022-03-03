using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class RoomFurnServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<RoomFurnServices> _logger;
        public const string ControllerName = "api/RoomFurn";

        public RoomFurnServices(HttpClient httpClient, SessionServices sessionServices, ILogger<RoomFurnServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<RoomFurn>> GetRoomFurns()
        {
            var res = await _httpClient.GetFromJsonAsync<List<RoomFurn>>(ControllerName);
            return res;
        }
        public async Task<RoomFurn> GetById(long id)
        {
            var res = await _httpClient.GetFromJsonAsync<RoomFurn>($"{ControllerName}?id={id}");
            return res;
        }
        public async Task<List<RoomFurn>> GetByRoom(int roomid)
        {
            var res = await _httpClient.GetFromJsonAsync<List<RoomFurn>>($"{ControllerName}/room/{roomid}");
            return res;
        }
        public async Task<bool> Create(RoomFurn item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<int> CreateMulit(IEnumerable<RoomFurn> items)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/createmulit", items);
            return await res.Content.ReadFromJsonAsync<int>();
        }
        public async Task<bool> Update(RoomFurn item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<int> UpdateMulit(IEnumerable<RoomFurn> items)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/UpdateMulit", items);
            return await res.Content.ReadFromJsonAsync<int>();
        }
         public async Task<bool> Delete(long furnId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", furnId);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<int> DeleteMulit(int roomId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/DeleteMulit", roomId);
            return await res.Content.ReadFromJsonAsync<int>();
        }

    }
}
