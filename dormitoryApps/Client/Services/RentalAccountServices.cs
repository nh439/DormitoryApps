using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class RentalAccountServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<RentalAccountServices> _logger;
        public const string ControllerName = "api/RentalAccount";

        public RentalAccountServices(HttpClient httpClient, SessionServices sessionServices, ILogger<RentalAccountServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<RentalAccount> Get(string accountId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<RentalAccount>($"{ControllerName}/{accountId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RentalAccount>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(RentalAccount item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RentalAccount>.Insert(), x);
            }
            return false;
        }
        public async Task<bool> Update(RentalAccount item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RentalAccount>.Update(), x);
            }
            return false;
        }
         public async Task<bool> Delete(string accountId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", accountId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RentalAccount>.Delete(), x);
            }
            return false;
        }

    }
}
