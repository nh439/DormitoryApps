using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IMeetingServices
    {
        Task<bool> Create(Meeting item);
    }
    public class MeetingServices : IMeetingServices
    {
        private readonly MeetingRepository _repository;
        private readonly MeetingAttachmentServices _attachmentService;
        private readonly MeetingAttendeeRepository _attendeeRepository;

        public MeetingServices(MeetingRepository repository, MeetingAttachmentServices attachmentService, MeetingAttendeeRepository attendeeRepository)
        {
            _repository = repository;
            _attachmentService = attachmentService;
            _attendeeRepository = attendeeRepository;
        }
        public async Task<bool> Create(Meeting item)

        {
            var res = await _repository.Create(item);
            if (!res) return false;
            await _attendeeRepository.Create(item.Attendees);
            if(item.Attachments != null && item.Attachments.Count > 0)
            {
                await _attachmentService.Create(item.Attachments);
            }
            return res;
        }
        public async Task<bool> Update(Meeting item)
        {
            var res = await _repository.Update(item);
            if (!res) return false;
            await _attendeeRepository.DeleteByMeetingId(item.Id);
            await _attendeeRepository.Create(item.Attendees);
            await _attachmentService.DeleteByMeetingId(item.Id);
            if(item.Attachments != null && item.Attachments.Count > 0)
            {
                await _attachmentService.Create(item.Attachments);
            }
            await Task.Delay(100);
            return true;
        }
    }
}
