using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Json;
using System.Net.Http.Json;
namespace dormitoryApps.Client.Services
{
    public class ClientdataServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ClientdataServices> _logger;
        public const string ControllerName = "data/";

        public ClientdataServices(HttpClient httpClient, ILogger<ClientdataServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<DefaultRental> GetDefaultRental()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<DefaultRental>($"{ControllerName}/Rental.json");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<DefaultRental>.Select(), x);
            }
            return null;
        }
        public async Task<Utilities> GetUtilities()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<Utilities>($"{ControllerName}/Utilities.json");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Utilities>.Select(), x);
            }
            return null;

        }
        public async Task<MyCompany> GetMyCompany()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<MyCompany>($"{ControllerName}/MyCompany.json");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<MyCompany>.Select(), x);
            }
            return null;
        }
     
    }
}
