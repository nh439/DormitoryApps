using Blazored.SessionStorage;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class SessionServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SessionServices> _logger;
        private readonly ISessionStorageService _sessionStorageService;
        private readonly NavigationManager _navigationManager;
        private readonly OfficerServices _officerServices;
        public const string ControllerName = "api/session";

        public SessionServices(HttpClient httpClient,
            ILogger<SessionServices> logger,
            ISessionStorageService sessionStorageService,
            NavigationManager navigationManager,
            OfficerServices officerServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionStorageService = sessionStorageService;
            _navigationManager = navigationManager;
            _officerServices = officerServices;
        }
        public async Task< List<Session>?> Get()
        {
            var res = await _httpClient.GetFromJsonAsync<List<Session>>(ControllerName);
            return res;
        }
        public async Task<List<Session>?> Get(long UserId)
        {
            var res = await _httpClient.GetFromJsonAsync<List<Session>>($"{ControllerName}/GetUser/{UserId}");
            return res;
        }
        public async Task<string> CreateLogin(long UserId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create",UserId);
            return await res.Content.ReadAsStringAsync();
        }
        public async Task<bool> FourceCheckout(long UserId)
        {
            var res = await _httpClient.GetAsync($"{ControllerName}/Force/{UserId}");
            return res.IsSuccessStatusCode;
        }
        public async Task<Officer?> GetCurrentLogin()
        {
            var currentId = await _sessionStorageService.GetItemAsync<string>("Id");
            Officer officer = await _httpClient.GetFromJsonAsync<Officer?>($"{ControllerName}/Get/{currentId}");
            return officer;
        }
        public async Task<bool> Permissioncheck()
        {
            var sessionId = await _sessionStorageService.GetItemAsync<string>("Id");
            if (string.IsNullOrEmpty(sessionId)) return false;
            var result = await _httpClient.PostAsJsonAsync($"{ControllerName}/Permissioncheck", sessionId);
            return result.IsSuccessStatusCode;
        }
        public async Task RequiredPermission()
        {
            var res = await Permissioncheck();
            if(res)
            {
                return;
            }
            await _officerServices.Logout();
            _navigationManager.NavigateTo("/", true);

        }

    }
}
