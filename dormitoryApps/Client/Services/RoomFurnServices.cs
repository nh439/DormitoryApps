using dormitoryApps.Client.Enum;
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
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomFurn>>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Select(), x);
            }
            return null;
        }
        public async Task<RoomFurn> GetById(long id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<RoomFurn>($"{ControllerName}?id={id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Select(), x);
            }
            return null;
        }
        public async Task<List<RoomFurn>> GetByRoom(int roomid)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomFurn>>($"{ControllerName}/room/{roomid}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(RoomFurn item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Insert(), x);
            }
            return false;
        }
        public async Task<int> CreateMulit(IEnumerable<RoomFurn> items)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/createmulit", items);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Insert(), x);
            }
            return -1;
        }
        public async Task<bool> Update(RoomFurn item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Update(), x);
            }
            return false;
        }
        public async Task<int> UpdateMulit(IEnumerable<RoomFurn> items)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/UpdateMulit", items);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Update(), x);
            }
            return null;
        }
         public async Task<bool> Delete(long furnId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", furnId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Delete(), x);
            }
            return false;
        }
        public async Task<int> DeleteMulit(int roomId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/DeleteMulit", roomId);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Delete(), x);
            }
            return -1;
        }

    }
}
 