using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;
using PagedList;
using dormitoryApps.Client.Enum;

namespace dormitoryApps.Client.Services
{
    public class RoomServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RoomServices> _logger;
        private readonly SessionServices _sessionServices;
        public const string ControllerName = "api/Room";

        public RoomServices(HttpClient httpClient, ILogger<RoomServices> logger, SessionServices sessionServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionServices = sessionServices;
        }
        public async Task<List<Room>> GetRooms()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Room>>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Room>.Select(), x);
            }
            return null;
        }
        public async Task<Room> GetRoom(int Id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<Room>($"{ControllerName}?id={Id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<List<Room>> GetByBuilding(int buildingId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Room>>($"{ControllerName}/building/{buildingId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<List<Room>> GetHasAircondition()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Room>>($"{ControllerName}/air");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<List<Room>> GetEnabled()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Room>>($"{ControllerName}/Enabled");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(Room item)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Insert(), x);
            }
            return false;
        }
        public async Task<bool> Update(Room item)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Update(), x);
            }
            return false;
        }
        public async Task<bool> Delete(int Id)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", Id);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Delete(), x);
            }
            return false;
        }
        public async Task<List<Room>> GetByPage(int buildingId, int page)
        {
            try
            {
                var Havepermission = _sessionServices.Permissioncheck();
                if (await Havepermission)
                {
                    var res = await _httpClient.GetFromJsonAsync<List<Room>>($"{ControllerName}/building/{buildingId}?page={page}");
                    return res;
                }
                return new List<Room>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomfurnTemplate>.Select(), x);
            }
            return null;
        }

    }
}
