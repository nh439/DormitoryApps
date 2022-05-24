using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class MeetingAttendeeRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "meetingattendee";

        public MeetingAttendeeRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(MeetingAttendee attendee)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<MeetingAttendee>(attendee);
            return res;
        }
        public async Task<int> Create(IEnumerable<MeetingAttendee> attendees)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<MeetingAttendee>(attendees);
            return res;
        }
        public async Task<List<MeetingAttendee>> GetByMeetingId(long meetingId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<MeetingAttendee>(TableName, $"MeetingId={meetingId}");
            return res.ToList();
        }
        public async Task<List<MeetingAttendee>> GetByUserId(long userId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<MeetingAttendee>(TableName, $"OfficerId={userId}");
            return res.ToList();
        }

    }
}
