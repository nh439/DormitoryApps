using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class BankServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BankServices> _logger;
        public const string ControllerName = "api/bank";

        public BankServices(HttpClient httpClient, ILogger<BankServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Bank>> Get()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<Bank>>(ControllerName);
                return result;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Bank>.Select(), x);
            }
            return null;
        }
        public async Task<Bank> Get(int id)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<Bank>($"{ControllerName}?id={id}");
                return result;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Bank>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(Bank item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Bank>.Select(), x);
            }
            return false;
        }
        public async Task<bool> Delete(int itemId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", itemId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Bank>.Select(), x);
            }
            return false;
        }

    }
}
