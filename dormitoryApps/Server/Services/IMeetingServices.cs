using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IMeetingServices
    {
        Task<bool> Create(Meeting item);
        Task<bool> Update(Meeting item);
        Task<bool> Delete(long id);
        Task<List<Meeting>> GetBySender(long senderId);
        Task<List<Meeting>> GetInvites(long userId);
        Task<Meeting> GetMeeting(long meetingId);
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
        public async Task<bool> Delete(long id)
        {
            return await _repository.Delete(id);
        }
        public async Task<List<Meeting>> GetBySender(long senderId)
        {
            var res = await _repository.GetBySender(senderId);
            if (res==null) return null;
            res.ForEach(async x =>
            {
                x.Attendees = await _attendeeRepository.GetByMeetingId(x.Id);
            });
            return res;
        }
        public async Task<List<Meeting>> GetInvites(long userId)
        {
            long[] Id = new long[0];
            await _attendeeRepository.GetByUserId(userId).ContinueWith(x =>
            {
                Id = x.Result.Select(x => x.MeetingId).ToArray();
            });
            var res = await _repository.GetRelated(Id);
            res.ForEach(async x =>
            {
                x.Attendees = await _attendeeRepository.GetByMeetingId(x.Id);
            });
            return res;
        }
        public async Task<Meeting> GetMeeting(long meetingId)
        {
            var res = await _repository.Get(meetingId);
            if (res == null) return null;
            res.Attachments = await _attachmentService.GetList(meetingId);
            res.Attendees = await _attendeeRepository.GetByMeetingId(meetingId);
            return res;
        }
    }
}
