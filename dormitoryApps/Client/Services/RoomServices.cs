using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;
using PagedList;

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
            var Havepermission = _sessionServices.Permissioncheck();
            if (await Havepermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Room>>(ControllerName);
                return res;
            }
            return new List<Room>();
        }
         public async Task<Room> GetRoom(int Id)
        {
            var Havepermission = _sessionServices.Permissioncheck();
            if (await Havepermission)
            {
                var res = await _httpClient.GetFromJsonAsync<Room>($"{ControllerName}?id={Id}");
                return res;
            }
            return new Room();
        }
        public async Task<List<Room>> GetByBuilding(int buildingId)
        {
            var Havepermission = _sessionServices.Permissioncheck();
            if (await Havepermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Room>>($"{ControllerName}/building/{buildingId}");
                return res;
            }
            return new List<Room>();
        }
        public async Task<List<Room>> GetHasAircondition()
        {
            var Havepermission = _sessionServices.Permissioncheck();
            if (await Havepermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Room>>($"{ControllerName}/air");
                return res;
            }
            return new List<Room>();
        }
         public async Task<List<Room>> GetEnabled()
        {
            var Havepermission = _sessionServices.Permissioncheck();
            if (await Havepermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Room>>($"{ControllerName}/Enabled");
                return res;
            }
            return new List<Room>();
        }
        public async Task<bool> Create(Room item)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Update(Room item)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
         public async Task<bool> Delete(int Id)
        {
            await _sessionServices.RequiredPermission();
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", Id);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<List<Room>> GetByPage(int buildingId,int page)
        {
            var Havepermission = _sessionServices.Permissioncheck();
            if (await Havepermission)
            {
                var res = await _httpClient.GetFromJsonAsync<List<Room>>($"{ControllerName}/building/{buildingId}?page={page}");
                return res;
            }
            return new List<Room>();
        }

    }
}
