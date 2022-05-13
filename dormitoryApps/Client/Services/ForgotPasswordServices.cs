using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using System.Net.Http.Json;
using System.Text;

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
            try
            {
                var res = await _httpClient.PostAsJsonAsync(ControllerName, item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<ForgotPassword>.Insert(), x);
            }
            return false;
        }
        public async Task<bool> TokenCheck(long UserId,string Token)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<bool>($"{ControllerName}?Id={UserId}&Token={Token}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<ForgotPassword>.Select(), x);
            }
            return false;
        }
        public async Task<ForgotPassword> Get(long UserId, string Token)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<ForgotPassword>(($"{ControllerName}/Get?Id={UserId}&Token={Token}"));
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<ForgotPassword>.Select(), x);
            }
            return null;
        }
        public async Task<ForgotPassword> GetWithPassword(int Password, long UserId)
        {
            try
            {
                LoginParameter item = new LoginParameter();
                string cipher = Password + "|" + UserId + "|" + item.Reference;
                item.Content = Encoding.ASCII.GetBytes(cipher);
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/PasswordCheck", item);
                return await res.Content.ReadFromJsonAsync<ForgotPassword>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<ForgotPassword>.Select(), x);
            }
            return null;
        }
        public async Task<int> Delete()
        {
            try
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
            catch (Exception x)
            {
                _logger.LogError(ServiceException<ForgotPassword>.Delete(), x);
            }
            return -1;
        }
        public async Task<bool> HadReset(long userId,string token)
        {
            try
            {
                object[] items = new object[] { userId, token };
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/HadReset", items);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<ForgotPassword>.Update(), x);
            }
            return false;
        }

    }
}
