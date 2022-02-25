using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class RoomfurnTemplateServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<RoomfurnTemplateServices> _logger;
        public const string ControllerName = "api/RoomfurnTemplate";

        public RoomfurnTemplateServices(HttpClient httpClient, SessionServices sessionServices, ILogger<RoomfurnTemplateServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<RoomfurnTemplate>> Get()
        {
            var res = await _httpClient.GetFromJsonAsync<List<RoomfurnTemplate>>(ControllerName);
            return res;
        }
        public async Task<RoomfurnTemplate> Get(long Id)
        {
            var res = await _httpClient.GetFromJsonAsync<RoomfurnTemplate>($"{ControllerName}?Id={Id}");
            return res;
        }
        public async Task<List<RoomfurnTemplate>> GetByType(string typeName)
        {
            var res = await _httpClient.GetFromJsonAsync<List<RoomfurnTemplate>>($"{ControllerName}/Type/{typeName}");
            return res;             
        }
        public async Task<bool> Create(RoomfurnTemplate template)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", template);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<int> Create(IEnumerable<RoomfurnTemplate> templates)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", templates);
            return await res.Content.ReadFromJsonAsync<int>();
        }
        public async Task<bool> Update(RoomfurnTemplate template)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", template);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete(long itemId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", itemId);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<int> DeleteTemplate(int roomId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/DeleteTemplate", roomId);
            return await res.Content.ReadFromJsonAsync<int>();
        }

    }
}
