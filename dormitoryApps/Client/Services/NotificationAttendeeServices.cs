using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class NotificationAttendeeServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AddressServices> _logger;
        public const string ControllerName = "api/NotificationAttendee";

        public NotificationAttendeeServices(HttpClient httpClient, ILogger<AddressServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<NotificationAttendee> Get(long userId, string notificationId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<NotificationAttendee>($"{ControllerName}?userId={userId}&notificationId={notificationId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<NotificationAttendee>.Select(), x);
                return null;
            }

        }
        public async Task<List<NotificationAttendee>> Get(long userId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<NotificationAttendee>>($"{ControllerName}?userId={userId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<NotificationAttendee>.Select(), x);
                return null;
            }
        }
        public async Task<List<NotificationAttendee>> Get(string notificationId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<NotificationAttendee>>($"{ControllerName}?notificationId={notificationId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<NotificationAttendee>.Select(), x);
                return null;
            }
        }
        public async Task<bool> Create(NotificationAttendee notification)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", notification);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<NotificationAttendee>.Insert(), x);
                return false;
            }
        }
        public async Task<int> Create(IEnumerable<NotificationAttendee> notifications)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Creates", notifications);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<NotificationAttendee>.Insert(), x);
                return -1;
            }
        }

         public async Task<int> Delete(string notificationId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Delete", notificationId);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<NotificationAttendee>.Delete(), x);
                return -1;
            }
        }
        public async Task<int> Delete(IEnumerable<string> notificationId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Deletes", notificationId);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<NotificationAttendee>.Select(), x);
                return -1;
            }
        }


    }
}
