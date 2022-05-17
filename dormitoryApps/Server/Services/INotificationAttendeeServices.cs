using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface INotificationAttendeeServices
    {
        Task<bool> Create(NotificationAttendee item);
        Task<int> Create(IEnumerable<NotificationAttendee> items);
        Task<int> Delete(string notificationId);
        Task<int> Delete(params string[] notificationId);
        Task<List<NotificationAttendee>> GetByNotification(string notificationId);
        Task<List<NotificationAttendee>> GetByUser(long userId);
        Task<NotificationAttendee> GetOne(long userId, string notificationId);
        Task<List<NotificationAttendee>> Getall();
    }
    public class NotificationAttendeeServices : INotificationAttendeeServices
    {
        private readonly NotificationAttendeeRepository _repository;

        public NotificationAttendeeServices(NotificationAttendeeRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(NotificationAttendee item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<NotificationAttendee> items)
        {
            return await _repository.Create(items);
        }
        public async Task<int> Delete(string notificationId)
        {
            return await _repository.Delete(notificationId);
        }
        public async Task<int> Delete(params string[] notificationId)
        {
            return await _repository.Delete(notificationId);
        }
        public async Task<List<NotificationAttendee>> GetByNotification(string notificationId)
        {
            return await _repository.GetByNotification(notificationId);
        }
        public async Task<List<NotificationAttendee>> GetByUser(long userId)
        {
            return await _repository.GetByUser(userId);
        }
        public async Task<NotificationAttendee> GetOne(long userId, string notificationId)
        {
            return await _repository.GetOne(userId,notificationId);
        }
        public async Task<List<NotificationAttendee>> Getall()
        {
            return await _repository.Getall();
        }

    }
}
