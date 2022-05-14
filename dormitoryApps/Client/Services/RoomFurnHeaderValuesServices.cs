using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace dormitoryApps.Client.Services
{
    public class RoomFurnHeaderValuesServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<RoomFurnHeaderValuesServices> _logger;
        public const string ControllerName = "api/RoomFurnHeaderValues";

        public RoomFurnHeaderValuesServices(HttpClient httpClient, SessionServices sessionServices, ILogger<RoomFurnHeaderValuesServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<RoomFurnHeaderValues>> GetValues()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomFurnHeaderValues>>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Select(), x);
            }
            return null;
        }
        public async Task<List<RoomFurnHeaderValues>> GetByHeader(long headerId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RoomFurnHeaderValues>>($"{ControllerName}/Header/{headerId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Select(), x);
            }
            return null;
        }
        public async Task<RoomFurnHeaderValues> GetById(long Id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<RoomFurnHeaderValues>($"{ControllerName}?Id={Id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(RoomFurnHeaderValues item)
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
        public async Task<int> Create(IEnumerable<RoomFurnHeaderValues> items)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", items);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Insert(), x);
            }
            return -1;
        }
        public async Task<bool> Update(RoomFurnHeaderValues item)
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
        public async Task<bool> Delete(long Id)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", Id);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RoomFurnHeaderValues>.Delete(), x);
            }
            return false;
        }
        public async Task<int> DeleteByHeader(long headerId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/DeleteByHeader", headerId);
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
