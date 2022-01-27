using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using System.Net.Http.Json;
namespace dormitoryApps.Client.Services
{
    public class OfficerServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<OfficerServices> _logger;
        public const string ControllerName = "api/officer";
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
        public async Task<List<Officer>> GetEmployee()
        {
            List<Officer> Employee = await _httpClient.GetFromJsonAsync<List<Officer>>(ControllerName);
            return Employee;
        }
        public async Task<Officer> GetById(long Id)
        {
            Officer officers = await _httpClient.GetFromJsonAsync<Officer>($"{ControllerName}/{Id}");
            return officers;
        }
        public async Task<bool> Create(Officer officer)
        {
            var res = await _httpClient.PostAsJsonAsync<Officer>($"{ControllerName}/Create", officer);
            return res.IsSuccessStatusCode;
        }
         public async Task<bool> Update(Officer officer)
        {
            var res = await _httpClient.PostAsJsonAsync<Officer>($"{ControllerName}/Update", officer);
            return res.IsSuccessStatusCode;
        }

    }
}
