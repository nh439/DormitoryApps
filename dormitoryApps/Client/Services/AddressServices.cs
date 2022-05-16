using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class AddressServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AddressServices> _logger;
        public const string ControllerName = "api/address";

        public AddressServices(HttpClient httpClient, ILogger<AddressServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<Address> GetAddress(string addressId)
        {
            try
            {
                Address address = await _httpClient.GetFromJsonAsync<Address>($"{ControllerName}/{addressId}");
                return address;
            }
            catch(Exception x)
            {
               _logger.LogError(ServiceException<Address>.Select(),x);
            }
            return null;
        }
        public async Task<bool> Create(Address address)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", address);
                return res.IsSuccessStatusCode;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Address>.Insert(), x);
            }
            return false;
        }
         public async Task<bool> Update(Address address)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync<Address>($"{ControllerName}/Update", address);
                return res.IsSuccessStatusCode;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Address>.Update(), x);
            }
            return false;
        }

    }
}
