

using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class RentalMemberServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RentalMemberServices> _logger;
        private readonly SessionServices _sessionServices;
        public const string ControllerName = "api/RentalMember";

        public RentalMemberServices(HttpClient httpClient, ILogger<RentalMemberServices> logger, SessionServices sessionServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionServices = sessionServices;
        }
        public async Task<bool> Create(RentalMember item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RentalMember>.Insert(), x);
            }
            return false;
        }
        public async Task<int> Create(IEnumerable< RentalMember> items)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", items);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RentalMember>.Insert(), x);
            }
            return -1;
        }
        public async Task<bool> Setmain(RentalMember mainmember)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Setmain", mainmember);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RentalMember>.Update(), x);
            }
            return false;
        }
        public async Task<List<RentalMember>> GetByRentalId(string rentalId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RentalMember>>($"{ControllerName}/Rental/{rentalId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RentalAccount>.Select(), x);
            }
            return null;
        }
        public async Task<List<RentalMember>> GetByMemberId(long Id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<RentalMember>>($"{ControllerName}/Member/{Id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<RentalAccount>.Select(), x);
            }
            return null;
        }

    }
}
