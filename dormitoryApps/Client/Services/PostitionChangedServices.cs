using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class PostitionChangedServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PostitionChangedServices> _logger;
        public const string ControllerName = "api/PostitionChanged";

        public PostitionChangedServices(HttpClient httpClient, ILogger<PostitionChangedServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<List<PostitionChanged>> GetPostitionChanged()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<PostitionChanged>>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PostitionChanged>.Select(), x);
            }
            return null;
        }
        public async Task<List<PostitionChanged>> GetByOfficer(long officerId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<PostitionChanged>>($"{ControllerName}?officerId={officerId}");
                return res;
            }
            catch(Exception x)
            {
                _logger.LogError(x.Message, x);
            }
            return null;
        }
        public async Task<bool> Create(PostitionChanged item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync(ControllerName, item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PostitionChanged>.Insert(), x);
            }
            return false;
        }
    }
}
