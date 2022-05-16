using dormitoryApps.Client.Enum;

namespace dormitoryApps.Client.Services
{
    public class EmailTemplateService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EmailTemplateService> _logger;
        public const string ControllerName = "EmailTemplate/";

        public EmailTemplateService(HttpClient httpClient, ILogger<EmailTemplateService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public string PatchData(string template,params object[] values)
        {
            return string.Format(template,values);
        }
        public async Task<string> GetCustomTemplate(string templatefile)
        {
            try
            {
                templatefile = templatefile.EndsWith(".txt") || templatefile.EndsWith(".html") ? templatefile : $"{templatefile}.txt";
                string content = await _httpClient.GetStringAsync($"{ControllerName}/{templatefile}");
                return content;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<string>.Select(), x);
            }
            return string.Empty;
        }
        public async Task<string> GetForgotPasswordWithToken()
        {
            try
            {
                string content = await _httpClient.GetStringAsync($"{ControllerName}/ForgotEmail.txt");
                return content;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<string>.Select(), x);
            }
            return string.Empty;
        }
    }
}
