using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class NotificationAttachmentRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "notificationattachment";

        public NotificationAttachmentRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<int> Create(IEnumerable<NotificationAttachment> attachments)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<NotificationAttachment>(attachments);
            return res;
        }
        public async Task<int> Delete(string notificationId)
        {
           var res = await _databases.Dorm.DeleteAsync(TableName,$"NotificationId='{notificationId}'");
           return res;
        }
        public async Task<List<NotificationAttachment>> GetByNotification(string NotificationId)
        {
            List<NotificationAttachment> res = new List<NotificationAttachment>();
            await _databases.Dorm.SelectEntitiesAsync<NotificationAttachment>(TableName, $"NotificationId='{NotificationId}'").ContinueWith(x =>
            {
                res = x.Result.ToList();
                res.ForEach(x => { x.FileContent = null; });
            });
            await Task.Delay(100);          
            return res;
        }
        public async Task<NotificationAttachment> GetAttachment(string attachmentId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<NotificationAttachment>(TableName, $"Id='{attachmentId}'");
            return res.FirstOrDefault();
        }


    }
}
