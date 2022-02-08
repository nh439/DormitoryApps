using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using System.Text;
namespace dormitoryApps.Client.Services
{
    public class OfficerServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<OfficerServices> _logger;
        private readonly ILocalStorageService _localStorageService;
        public const string ControllerName = "api/officer";
        public OfficerServices(HttpClient httpClient, 
            ILogger<OfficerServices> logger,
            ILocalStorageService sessionStorageService)
        {
            _httpClient = httpClient;
            _logger = logger;
            _localStorageService = sessionStorageService;
        }
        public async Task<bool> GetLogin (string username, string password)
        {
            var item = new LoginParameter { Username = ASCIIEncoding.ASCII.GetBytes(username), Password = ASCIIEncoding.ASCII.GetBytes(password) };
            var response = await _httpClient.PostAsJsonAsync($"{ ControllerName}/Login", item);
            if(!response.IsSuccessStatusCode)
            {
                return false;
            }
            return await response.Content.ReadFromJsonAsync<bool>();
        }
        public async Task Logout()
        {
            await _localStorageService.ClearAsync();
            await _httpClient.GetAsync($"{ ControllerName}/Logout");
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
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", officer);
                return res.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         public async Task<bool> Update(Officer officer)
        {
            var res = await _httpClient.PostAsJsonAsync<Officer>($"{ControllerName}/Update", officer);
            return res.IsSuccessStatusCode;
        }
        public async Task<Officer> GetByUsername(string username)
        {
            Officer officer = await _httpClient.GetFromJsonAsync<Officer>($"{ControllerName}/User/{username}");
            return officer;
        }     
        public async Task<int?> PostitionUpgrade(IEnumerable<NewPostitionParameter> items)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Upgrade", items);
            return await res.Content.ReadFromJsonAsync<int>();
        }
        public async Task<bool> GetExistUsername(string username)
        {
            var res = await _httpClient.GetFromJsonAsync<bool>($"{ControllerName}/ExistUsername/{username}");
            return res;
        }
         public async Task<bool> GetExistEmail(string Email)
        {
            var res = await _httpClient.GetFromJsonAsync<bool>($"{ControllerName}/ExistEmail/{Email}");
            return res;
        }

    }
}
