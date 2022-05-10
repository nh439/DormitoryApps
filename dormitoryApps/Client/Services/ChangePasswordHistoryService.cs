using dormitoryApps.Client.Enum;
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
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<ChangePasswordHistory>>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<ChangePasswordHistory>.Select(), x);
            }
            return null;
        }
        public async Task<List<ChangePasswordHistory>> Get(long officerId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<ChangePasswordHistory>>($"{ControllerName}?userId={officerId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<ChangePasswordHistory>.Select(), x);
            }
            return null;
        }
        public async Task<int> Delete(int month)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync(ControllerName, month);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<ChangePasswordHistory>.Select(), x);
            }
            return -1;
        }
    }
}
