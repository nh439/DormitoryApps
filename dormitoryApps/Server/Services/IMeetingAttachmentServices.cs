using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IMeetingAttachmentServices
    {
        Task<int> Create(IEnumerable<MeetingAttachment> attachments);
        Task<List<MeetingAttachment>> GetList(long meetingId);
        Task<MeetingAttachment> GetAttachment(string attachmentId);
        Task DeleteByMeetingId(long meetingId);
    }
    public class MeetingAttachmentServices : IMeetingAttachmentServices
    {
        private readonly MeetingAttachmentRepository _repository;

        public MeetingAttachmentServices(MeetingAttachmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Create(IEnumerable<MeetingAttachment> attachments)
        {
            return await _repository.Create(attachments);
        }
        public async Task<List<MeetingAttachment>> GetList(long meetingId)
        {
            return await _repository.GetList(meetingId);
        }
        public async Task<MeetingAttachment> GetAttachment(string attachmentId)
        {
            return await _repository.GetAttachment(attachmentId);
        }
        public async Task DeleteByMeetingId(long meetingId)
        {
            return
        }

    }
}
