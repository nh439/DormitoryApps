using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class ChangePasswordHistoryService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DepartmentServices> _logger;
        public const string ControllerName = "api/ChangePasswordHistory";

        public ChangePasswordHistoryService(HttpClient httpClient, ILogger<DepartmentServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        
        public async Task<List<ChangePasswordHistory>> Get()
        {
            var res = await _httpClient.GetFromJsonAsync<List<ChangePasswordHistory>>(ControllerName);
            return res;
        }
        public async Task<List<ChangePasswordHistory>> Get(long officerId)
        {
            var res = await _httpClient.GetFromJsonAsync<List<ChangePasswordHistory>>($"{ControllerName}?userId={officerId}");
            return res;
        }
        public async Task<int> Delete(int month)
        {
            var res = await _httpClient.PostAsJsonAsync(ControllerName, month);
            return await res.Content.ReadFromJsonAsync<int>();
        }
    }
}
