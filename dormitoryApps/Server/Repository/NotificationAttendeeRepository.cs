using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class NotificationAttendeeRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "notificationattendee";
        public NotificationAttendeeRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(NotificationAttendee item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<NotificationAttendee>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable<NotificationAttendee> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<NotificationAttendee>(items);
            return res;
        }
        public async Task<int> Delete(string notificationId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"NotificationId='{notificationId}'");
            return res;
        }
        public async Task<int> Delete(params string[] notificationId)
        {
            ConditionSet conditionSet = new ConditionSet();
            conditionSet.AddIn("NotificationId",notificationId);
            var res = await _databases.Dorm.DeleteAsync(TableName, conditionSet);
            return res;
        }        
        public async Task<List<NotificationAttendee>> GetByNotification(string notificationId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<NotificationAttendee>(TableName,$"NotificationId='{notificationId}'");
            return res.ToList();
        }
        public async Task<List<NotificationAttendee>> GetByUser(long userId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<NotificationAttendee>(TableName, $"UserId={userId}");
            return res.ToList();
        }
        public async Task<List<NotificationAttendee>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<NotificationAttendee>();
            return res.ToList();
        }
        public async Task<NotificationAttendee> GetOne(long userId, string notificationId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<NotificationAttendee>(TableName, $"UserId={userId} and NotificationId='{notificationId}'");
            return res.FirstOrDefault();
        }
    }
}
