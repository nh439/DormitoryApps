using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;
using dormitoryApps.Client.Enum;

namespace dormitoryApps.Client.Services
{
    public class PostitionLineService
    {
        private readonly HttpClient _httpClient;
        private readonly SessionServices _sessionServices;
        private readonly ILogger<PostitionLineService> _logger;
        public const string ControllerName = "api/PostitionLine";

        public PostitionLineService(HttpClient httpClient, SessionServices sessionServices, ILogger<PostitionLineService> logger)
        {
            _httpClient = httpClient;
            _sessionServices = sessionServices;
            _logger = logger;
        }
        public async Task<List<PostitionLine>> GetPostitionLines()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<PostitionLine>>(ControllerName);
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PostitionLine>.Select(), x);
            }
            return null;
        }
        public async Task<PostitionLine> GetById(int id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<PostitionLine>($"{ControllerName}?id={id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PostitionLine>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(PostitionLine line)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", line);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PostitionLine>.Insert(), x);
            }
            return false;
        }
         public async Task<bool> Update(PostitionLine line)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", line);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PostitionLine>.Update(), x);
            }
            return false;
        }
        public async Task<bool> Delete (int plId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", plId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<PostitionLine>.Delete(), x);
            }
            return false;
        }

    }
}
