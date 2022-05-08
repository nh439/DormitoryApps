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

            var result = await _httpClient.GetFromJsonAsync<List<Bank>>(ControllerName);
            return result;
        }
        public async Task<Bank> Get(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Bank>($"{ControllerName}?id={id}");
            return result;
        }
        public async Task<bool> Create(Bank item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Delete(int itemId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", itemId);
            return await res.Content.ReadFromJsonAsync<bool>();
        }

    }
}
