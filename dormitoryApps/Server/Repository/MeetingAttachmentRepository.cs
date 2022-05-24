using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class MeetingAttachmentRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "meetingattachment";
       
        public MeetingAttachmentRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<int> Create(IEnumerable<MeetingAttachment> attachments)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<MeetingAttachment>(attachments);
            return res;
        }
    }
}
