using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface INotificationServices
    {
        Task<bool> Create(Notification item);
        Task<bool> Edit(Notification item);
        Task<bool> Delete(string notificationId);
        Task<bool> DeleteAfter(int day);
        Task<List<Notification>> Getall();
        Task<List<Notification>> GetForUserId(long userId);
        Task<Notification> GetNotification(string notificationId);
    }
    public class NotificationServices : INotificationServices
    {
        private readonly NotificationRepository _repository;
        private readonly NotificationAttachmentRepository _attachmentRepository;
        private readonly NotificationAttendeeRepository _attendeeRepository;

        public NotificationServices(NotificationRepository repository, NotificationAttachmentRepository attachmentRepository, NotificationAttendeeRepository attendeeRepository)
        {
            _repository = repository;
            _attachmentRepository = attachmentRepository;
            _attendeeRepository = attendeeRepository;
        }
        public async Task<bool> Create(Notification item)
        {
            var res = await _repository.Create(item);
            if (!res) return false;
            if (item.Attendees != null && item.Attendees.Count > 0)
            {
                item.Attendees.ForEach(x =>
                {
                    x.NotificationId = item.Id;
                });
                await _attendeeRepository.Create(item.Attendees);
            }
            if (item.Attachments != null && item.Attachments.Count > 0)
            {
                item.Attachments.ForEach(x =>
                {
                    x.NotificationId = item.Id;
                });
                await _attachmentRepository.Create(item.Attachments);
            }
            return true ;

        }
        public async Task<bool> Edit(Notification item)
        {
            return await _repository.Edit(item);
        }
        public async Task<bool> Delete(string notificationId)
        {
            return await _repository.Delete(notificationId);
        }
        public async Task<bool> DeleteAfter(int day)
        {
            return await _repository.DeleteAfter(day);
        }
        public async Task<List<Notification>> Getall()
        {
            var res = await _repository.Getall();
            var attendee = await _attendeeRepository.Getall();
            res.ForEach(x =>
            {
                x.Attendees = attendee.Where(y => y.NotificationId == x.Id).ToList();
            });
            return res;
        }
        public async Task<List<Notification>> GetForUserId(long userId)
        {
            var res = await _repository.GetForUserId(userId);
            var attendee = await _attendeeRepository.GetByUser(userId);
            res.ForEach(x =>
            {
                x.Attendees = attendee.Where(y => y.NotificationId == x.Id).ToList();
            });
            return res;
        }
        public async Task<Notification> GetNotification(string notificationId)
        {
            var res = await _repository.GetNotification(notificationId);
            if (res == null) return new Notification();
            res.Attendees = await _attendeeRepository.GetByNotification(notificationId);
            res.Attachments = await _attachmentRepository.GetByNotification(notificationId);
            return res;
        }

    }
}
