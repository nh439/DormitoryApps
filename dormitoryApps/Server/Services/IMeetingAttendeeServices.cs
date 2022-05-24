using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IMeetingAttendeeServices
    {
        Task<bool> Create(MeetingAttendee attendee);
        Task<int> Create(IEnumerable<MeetingAttendee> attendees);
        Task<List<MeetingAttendee>> GetByMeetingId(long meetingId);
        Task<List<MeetingAttendee>> GetByUserId(long userId);
    }
    public class MeetingAttendeeServices : IMeetingAttendeeServices
    {
        private readonly MeetingAttendeeRepository _repository;

        public MeetingAttendeeServices(MeetingAttendeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(MeetingAttendee attendee)
        {
            return await _repository.Create(attendee);
        }
        public async Task<int> Create(IEnumerable<MeetingAttendee> attendees)
        {
            return await _repository.Create(attendees);
        }
        public async Task<List<MeetingAttendee>> GetByMeetingId(long meetingId)
        {
            return await _repository.GetByMeetingId(meetingId);
        }
        public async Task<List<MeetingAttendee>> GetByUserId(long userId)
        {
            return await _repository.GetByUserId(userId);
        }

    }
}
