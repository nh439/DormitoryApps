using System.Net.Http.Json;
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
            var res = await _httpClient.GetFromJsonAsync<List<Member>>(ControllerName);
            return res;
        }
        public async Task<List<Member>> GetMembers(IEnumerable<long> IdCollection)
        {
            var res = await _httpClient.PostAsJsonAsync(ControllerName,IdCollection);
            return await res.Content.ReadFromJsonAsync<List<Member>>();
        }
        public async Task<Member> GetMember(long Id)
        {
            var res = await _httpClient.GetFromJsonAsync<Member>($"{ControllerName}?Id={Id}");
            return res;
        }
        public async Task<bool> Create(Member member)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", member);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<bool> Update(Member member)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", member);
            return await res.Content.ReadFromJsonAsync<bool>();
        }
        public async Task<int> Create(IEnumerable<Member> members)
        {
            var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", members);
            return await res.Content.ReadFromJsonAsync<int>();
        }
    }
}
