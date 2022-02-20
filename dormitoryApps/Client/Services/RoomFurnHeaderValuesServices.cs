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
            var res = await _httpClient.GetFromJsonAsync<List<RoomFurnHeaderValues>>(ControllerName);
            return res;         
        }
        public async Task<List<RoomFurnHeaderValues>> GetByHeader(long headerId)
        {
            var res = await _httpClient.GetFromJsonAsync<List<RoomFurnHeaderValues>>($"{ControllerName}/Header/{headerId}");
            return res;
        }
        public async Task<RoomFurnHeaderValues> GetById(long Id)
        {
            var res = await _httpClient.GetFromJsonAsync<RoomFurnHeaderValues>($"{ControllerName}?Id={Id}");
            return res;
        }
        public async Task<bool> Create(RoomFurnHeaderValues item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<int> Create(IEnumerable<RoomFurnHeaderValues> items)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", items);
            return await res.Content.ReadFromJsonAsync<int>();
        }
        public async Task<bool> Update(RoomFurnHeaderValues item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete(long Id)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", Id);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<int> DeleteByHeader(long headerId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/DeleteByHeader", headerId);
            return await res.Content.ReadFromJsonAsync<int>();
        }

    }
}
