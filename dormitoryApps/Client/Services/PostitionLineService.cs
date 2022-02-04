using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class PostitionLineService
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<PostitionLineService> _logger;
        public const string ControllerName = "api/PostitionLine";

        public PostitionLineService(HttpClient httpClient, SessionServices sessionServices, ILogger<PostitionLineService> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<PostitionLine>> GetPostitionLines()
        {
            var res = await _httpClient.GetFromJsonAsync<List<PostitionLine>>(ControllerName);
            return res;
        }
        public async Task<PostitionLine> GetById(int id)
        {
            var res = await _httpClient.GetFromJsonAsync<PostitionLine>($"{ControllerName}?id={id}");
            return res;
        }
        public async Task<bool> Create(PostitionLine line)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", line);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
         public async Task<bool> Update(PostitionLine line)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", line);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete (int plId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", plId);
            return await res.Content.ReadFromJsonAsync<bool>();
        }

    }
}
