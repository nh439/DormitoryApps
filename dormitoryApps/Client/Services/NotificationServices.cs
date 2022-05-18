using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;
namespace dormitoryApps.Client.Services
{
    public class NotificationServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AddressServices> _logger;
        private readonly SessionServices _sessionServices;
        public const string ControllerName = "api/Notification";

        public NotificationServices(HttpClient httpClient,
            ILogger<AddressServices> logger,
            SessionServices sessionServices)
        {
            _httpClient = httpClient;
            _logger = logger;
            _sessionServices = sessionServices;

        }

        public async Task<List<Notification>> Get()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Notification>>(ControllerName);
                return res.OrderByDescending(x => x.Date).ToList();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Select(), x);
            }
            return null;
        }
        public async Task<List<Notification>> Get(int lastestTake)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Notification>>(ControllerName);
                return res.OrderByDescending(x => x.Date).Take(lastestTake).ToList();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Select(), x);
            }
            return null;
        }
        public async Task<List<Notification>> Getall()
        {
            var isAdmin = await _sessionServices.IsAdmin();
            if (!isAdmin) return new List<Notification>();
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Notification>>(ControllerName + "/all");
                return res.OrderByDescending(x => x.Date).ToList();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Select(), x);
            }
            return null;
        }
        public async Task<Notification> GetById(string notificationId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<Notification>($"{ControllerName}/{notificationId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Select(), x);
            }
            return null;
        }
        public async Task<bool> Create(Notification item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync(ControllerName + "/Create", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Insert(), x);
            }
            return false;
        }
        public async Task<bool> Update(Notification item)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync(ControllerName + "/Update", item);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Update(), x);
            }
            return false;
        }
        public async Task<bool> Delete(string notificationId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync(ControllerName + "/Delete", notificationId);
                return await res.Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<Notification>.Delete(), x);
            }
            return false;
        }
        public async Task<bool> DeleteAfter(int days)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync(ControllerName + "/Deleteafter", days);
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
