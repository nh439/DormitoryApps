using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class NotificationAttachmentService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<BankServices> _logger;
        public const string ControllerName = "api/NotificationAttachment";

        public NotificationAttachmentService(HttpClient httpClient, ILogger<BankServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<List<NotificationAttachment>> GetByNotification(string notificationId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<NotificationAttachment>>($"{ControllerName}/{notificationId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<NotificationAttachment>.Select(), x);
                return null;
            }          
        }
        public async Task<NotificationAttachment> GetAttachment(string id)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<NotificationAttachment>($"{ControllerName}/GetAttachment/{id}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<NotificationAttachment>.Select(), x);
                return null;
            }
        }
    }
}
