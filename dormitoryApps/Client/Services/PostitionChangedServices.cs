using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class PostitionChangedServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PostitionChangedServices> _logger;
        public const string ControllerName = "api/PostitionChanged";

        public PostitionChangedServices(HttpClient httpClient, ILogger<PostitionChangedServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<List<PostitionChanged>> GetPostitionChanged()
        {
            var res = await _httpClient.GetFromJsonAsync<List<PostitionChanged>>(ControllerName);
            return res;
        }
        public async Task<List<PostitionChanged>> GetByOfficer(long officerId)
        {
            var res = await _httpClient.GetFromJsonAsync<List<PostitionChanged>>($"{ControllerName}?officerId={officerId}");
            return res;
        }
        public async Task<bool> Create(PostitionChanged item)
        {
            var res = await _httpClient.PostAsJsonAsync(ControllerName,item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
    }
}
