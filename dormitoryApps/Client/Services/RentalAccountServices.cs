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
            var res = await _httpClient.GetFromJsonAsync<RentalAccount>($"{ControllerName}/{accountId}");
            return res;
        }
        public async Task<bool> Create(RentalAccount item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Update(RentalAccount item)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
         public async Task<bool> Delete(string accountId)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", accountId);
            return await res.Content.ReadFromJsonAsync<bool>();
        }

    }
}
