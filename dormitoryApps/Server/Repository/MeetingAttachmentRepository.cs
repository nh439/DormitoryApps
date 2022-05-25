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
        public async Task<List<MeetingAttachment>> GetList(long meetingId)
        {
            List<MeetingAttachment> res = new List<MeetingAttachment>();
            await _databases.Dorm.SelectEntitiesAsync<MeetingAttachment>(TableName, $"MeetingId={meetingId}").ContinueWith(x =>
            {
                res = x.Result.ToList();
                res.ForEach(y =>
                {
                    y.FileContent = null;
                });
            });
            await Task.Delay(10);
            return res;
        }
        public async Task<MeetingAttachment> GetAttachment(string attachmentId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<MeetingAttachment>(TableName, $"id='{attachmentId}'");
            return res.FirstOrDefault();
        }
    }
}
