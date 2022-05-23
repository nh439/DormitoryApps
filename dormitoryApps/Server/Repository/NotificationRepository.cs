using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class NotificationRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "notification";

        public NotificationRepository(DBConnection databases)
        {
            _databases = databases;
        }

        public async Task<bool> Create(Notification item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Notification>(item);
            return res;
        }
        public async Task<bool> Edit(Notification item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<Notification>(item, $"Id='{item.Id}'");
            return res == 1;
        }
        public async Task<bool> Delete(string notificationId)
        {
            StoredProcedureContrainer contrainer = new StoredProcedureContrainer("sp_deleteNotificationById");
            contrainer.Addparameters("notiid", notificationId);
            var result = await _databases.Dorm.ExecuteStoredProcedureAsync(contrainer);
            return result.HasCompleted;
        }
        public async Task<bool> DeleteAfter(int day)
        {
            StoredProcedureContrainer contrainer = new StoredProcedureContrainer("sp_deletenotificationafterday");
            contrainer.Addparameters("afterday", day);
            var result = await _databases.Dorm.ExecuteStoredProcedureAsync(contrainer);
            return result.HasCompleted;
        }
        public async Task<List<Notification>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Notification>();
            return res.ToList();
        }
        public async Task<List<Notification>> GetForUserId(long userId)
        {
            string condition = $"Id in (select NotificationId from notificationattendee where UserId={userId}) or SendAll=1";
            var res = await _databases.Dorm.SelectEntitiesAsync<Notification>(TableName, condition);
            return res.OrderByDescending(x => x.Date).ToList();
        }
        public async Task<List<Notification>> GetBySender(long senderUserId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Notification>(TableName, $"SenderId={senderUserId}");
            return res.ToList();
        }
        public async Task<Notification> GetNotification(string notificationId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Notification>(TableName, $"Id='{notificationId}'");
            return res.FirstOrDefault();
        }
    }
}
