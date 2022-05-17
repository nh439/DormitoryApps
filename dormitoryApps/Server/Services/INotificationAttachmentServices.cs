using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface INotificationAttachmentServices
    {
        Task<int> Create(IEnumerable<NotificationAttachment> attachments);
        Task<int> Delete(string notificationId);
        Task<List<NotificationAttachment>> GetByNotification(string NotificationId);
        Task<NotificationAttachment> GetAttachment(string attachmentId);
    }
    public class NotificationAttachmentService : INotificationAttachmentServices
    {
        private readonly NotificationAttachmentRepository _repository;
        public NotificationAttachmentService(NotificationAttachmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Create(IEnumerable<NotificationAttachment> attachments)
        {
            return await _repository.Create(attachments);
        }
        public async Task<int> Delete(string notificationId)
        {
            return await _repository.Delete(notificationId);
        }
        public async Task<List<NotificationAttachment>> GetByNotification(string NotificationId)
        {
            return await _repository.GetByNotification(NotificationId);
        }
        public async Task<NotificationAttachment> GetAttachment(string attachmentId)
        {
            return await _repository.GetAttachment(attachmentId);
        }
    }
}
