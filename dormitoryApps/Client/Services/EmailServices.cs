using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Other;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class EmailServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EmailServices> _logger;
        public const string ControllerName = "api/email";

        public EmailServices(HttpClient httpClient, ILogger<EmailServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<bool> SendAsync(MailRequest item)
        {
            try
            {
              var res =  await _httpClient.PostAsJsonAsync(ControllerName, item);
              return res.IsSuccessStatusCode;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<MailRequest>.Insert(), x);
            }
            return false;
        }
    }
}
