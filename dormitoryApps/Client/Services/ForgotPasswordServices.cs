using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class ForgotPasswordServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ForgotPasswordServices> _logger;
        private readonly SessionServices _sessionServices;
        public const string ControllerName = "api/ForgotPassword";

        public ForgotPasswordServices(HttpClient httpClient, ILogger<ForgotPasswordServices> logger,SessionServices sessionServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionServices = sessionServices;
        }
        public async Task<bool> Create(ForgotPassword item)
        {
            var res = await _httpClient.PostAsJsonAsync(ControllerName, item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> TokenCheck(long UserId,string Token)
        {
            var res = await _httpClient.GetFromJsonAsync<bool>($"{ControllerName}?Id={UserId}&Token={Token}");
            return res;
        }
        public async Task<ForgotPassword> Get(long UserId, string Token)
        {
            var res = await _httpClient.GetFromJsonAsync<ForgotPassword>(($"{ControllerName}/Get?Id={UserId}&Token={Token}"));
            return res;
        }
        public async Task<int> Delete()
        {
            long currentUserId = 0;
            await _sessionServices.GetCurrentLogin().ContinueWith(c =>
            {
                currentUserId = c.Result.Id;
            });
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", currentUserId);
            if (!res.IsSuccessStatusCode) return -1;
            return await res.Content.ReadFromJsonAsync<int>();
        }

    }
}
