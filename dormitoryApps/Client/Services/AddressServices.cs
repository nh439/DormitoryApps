using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class AddressServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DepartmentServices> _logger;
        public const string ControllerName = "api/address";

        public AddressServices(HttpClient httpClient, ILogger<DepartmentServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<Address> GetAddress(string addressId)
        {
            Address address = await _httpClient.GetFromJsonAsync<Address>($"{ControllerName}/{addressId}");
            return address;
        }
        public async Task<bool> Create(Address address)
        {
            var res = await _httpClient.PostAsJsonAsync<Address>($"{ControllerName}/Create",address);
            return res.IsSuccessStatusCode;
        }
         public async Task<bool> Update(Address address)
        {
            var res = await _httpClient.PostAsJsonAsync<Address>($"{ControllerName}/Update",address);
            return res.IsSuccessStatusCode;
        }

    }
}
