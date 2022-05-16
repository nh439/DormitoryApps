using System.Net.Http.Json;
using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
namespace dormitoryApps.Client.Services
{
    public class MemberServices
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<MemberServices> _logger;
        public const string ControllerName = "api/Member";

        public MemberServices(HttpClient httpClient, SessionServices sessionServices, ILogger<MemberServices> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<Member>> GetMembers()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Member>>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Member>.Select(), x);
            }
            return null;
        }
        public async Task<List<Member>> GetMembers(IEnumerable<long> IdCollection)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync(ControllerName, IdCollection);
                return await res.Content.ReadFromJsonAsync<List<Member>>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Member>.Select(), x);
            }
            return null;
        }
        public async Task<Member> GetMember(long Id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<Member>($"{ControllerName}?Id={Id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Member>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(Member member)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", member);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Member>.Insert(), x);
            }
            return false;
        }
        public async Task<bool> Update(Member member)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", member);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Member>.Update(), x);
            }
            return false;
        }
        public async Task<int> Create(IEnumerable<Member> members)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", members);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Member>.Insert(), x);
            }
            return -1;
        }
    }
}
