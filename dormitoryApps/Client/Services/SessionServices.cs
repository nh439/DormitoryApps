using Blazored.SessionStorage;
using Blazored.LocalStorage;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using dormitoryApps.Shared.Model.Other;

namespace dormitoryApps.Client.Services
{
    public class SessionServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SessionServices> _logger;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;
        private readonly OfficerServices _officerServices;
        public const string ControllerName = "api/session";

        public SessionServices(HttpClient httpClient,
            ILogger<SessionServices> logger,
            ILocalStorageService localStorageService,
            NavigationManager navigationManager,
            OfficerServices officerServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _localStorageService = localStorageService;
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
            var currentId = await _localStorageService.GetItemAsync<string>("Id");
            Officer officer = await _httpClient.GetFromJsonAsync<Officer?>($"{ControllerName}/Get/{currentId}");
            officer.Password = "PA$$WORD";
            officer.Idx = "INDEX";
            return officer;
        }
        public async Task<bool> Permissioncheck()
        {
            var sessionId = await _localStorageService.GetItemAsync<string>("Id");
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
        public async Task<bool> IsAdmin()
        {
            var currentOfficer = await GetCurrentLogin();
            if(currentOfficer == null)
            {
                return false;
            }
            return currentOfficer.Issuper;
        }
        public async Task<List<Session>> GetWithAdvanceSearch(SessionAdvancedSearchCriteria criteria)
        {
            var res = await _httpClient.PostAsJsonAsync(ControllerName, criteria);
            return await res.Content.ReadFromJsonAsync<List<Session>>();
        }
        public async Task<int> Superlogout(int loggedInDay)
        {
            if (loggedInDay < 1) return 0;
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/SuperForce", loggedInDay);
            return await res.Content.ReadFromJsonAsync<int>();
        }
        public async Task<int> Delete(int month)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", month);
            return await res.Content.ReadFromJsonAsync<int>();
        }
    }
}
