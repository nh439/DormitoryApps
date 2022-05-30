using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class MeetingAttachmentController : Controller
    {
        private readonly IMeetingAttachmentServices _meetingAttachmentServices;
        private readonly ILogger<MeetingAttachmentController> _logger;
        private const string BaseUrl = "/api/meetingattachment";

        public MeetingAttachmentController(IMeetingAttachmentServices meetingAttachmentServices, ILogger<MeetingAttachmentController> logger)
        {
            _meetingAttachmentServices = meetingAttachmentServices;
            _logger = logger;
        }

        [HttpGet(BaseUrl+"/{meetingId}")]
        public async Task<IActionResult> Index(long meetingId)
        {
            try
            {
                var res = await _meetingAttachmentServices.GetList(meetingId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(500, x, x.Message);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl)]
        public async Task<IActionResult> GetAttachment([FromBody]string attachmentId)
        {
            try
            {
                var res = await _meetingAttachmentServices.GetAttachment(attachmentId);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(500, x, x.Message);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost(BaseUrl+"/Create")]
        public async Task<IActionResult> Create([FromBody]IEnumerable<MeetingAttachment> attachments)
        {
            try
            {
                var res = await _meetingAttachmentServices.Create(attachments);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(500, x, x.Message);
                return StatusCode(500, "Something Went Wrong");
            }
        }

    }
}
