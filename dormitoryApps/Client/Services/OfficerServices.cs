using dormitoryApps.Shared.Model.Other;
using System.Net.Http.Json;
namespace dormitoryApps.Client.Services
{
    public class OfficerServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<OfficerServices> _logger;
        public const string ControllerName = "/officer";
        public OfficerServices(HttpClient httpClient, ILogger<OfficerServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<bool> GetLogin (string username, string password)
        {
            var item = new LoginParameter { Username = username, Password = password };
            var response = await _httpClient.PostAsJsonAsync($"{ ControllerName}/Login", item);
            if(!response.IsSuccessStatusCode)
            {
                return false;
            }
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
