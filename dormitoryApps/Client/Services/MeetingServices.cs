using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class MeetingServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MeetingServices> _logger;
        private readonly SessionServices _sessionServices;
        public const string ControllerName = "api/Meeting";

        public MeetingServices(HttpClient httpClient, ILogger<MeetingServices> logger, SessionServices sessionServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionServices = sessionServices;
        }
        public async Task<List<Meeting>> GetInvites()
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.GetFromJsonAsync<List<Meeting>>(ControllerName);
                return res;               
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Select(), x);
            }
            return null;
        }
        public async Task<List<Meeting>>GetSent()
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.GetFromJsonAsync<List<Meeting>>($"{ControllerName}/Sender");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Select(), x);
            }
            return null;
        }
        public async Task<Meeting> GetMeeting(long meetingId)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                Meeting meeting = await _httpClient.PostAsJsonAsync<Meeting>(ControllerName, meetingId);
                return meeting;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(Meeting item)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Insert(), x);
            }
            return false;
        }
        public async Task<bool> Update(Meeting item)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Update", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Update(), x);
            }
            return false;
        }
         public async Task<bool> Update(long meetingId)
        {
            try
            {
                await _sessionServices.RequiredPermission();
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", meetingId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Delete(), x);
            }
            return false;
        }

    }
}
