using dormitoryApps.Client.Enum;
using dormitoryApps.Shared.Model.Entity;
using System.Net.Http.Json;

namespace dormitoryApps.Client.Services
{
    public class MeetingAttachmentServices
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MeetingAttachmentServices> _logger;
        public const string ControllerName = "api/meetingattachment";

        public MeetingAttachmentServices(HttpClient httpClient, ILogger<MeetingAttachmentServices> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<int> Create(IEnumerable<MeetingAttachment> items)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync($"{ControllerName}/Create", items);
                return await res.Content.ReadFromJsonAsync<int>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<MeetingAttachment>.Insert(), x);
            }
            return -1;
        }
        public async Task<List<MeetingAttachment>> GetList(long meetingId)
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<MeetingAttachment>>($"{ControllerName}/{meetingId}");
                return res;
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<MeetingAttachment>.Select(), x);
            }
            return null;
        }
        public async Task<MeetingAttachment> GetAttachment(string attachmentId)
        {
            try
            {
                var res = await _httpClient.PostAsJsonAsync(ControllerName, attachmentId);
                return await res.Content.ReadFromJsonAsync<MeetingAttachment>();
            }
            catch (Exception x)
            {
                _logger.LogError(ServiceException<MeetingAttachment>.Select(), x);
            }
            return null;
        }
    }
}
