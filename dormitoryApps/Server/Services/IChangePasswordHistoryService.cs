using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IChangePasswordHistoryService
    {
        Task<List<ChangePasswordHistory>> Get();
        Task<List<ChangePasswordHistory>> Get(long officerId);
        Task<int> Delete(int month);
    }
    public class ChangePasswordHistoryService : IChangePasswordHistoryService
    {
        private readonly ChangePasswordHistoryRepository _repository;

        public ChangePasswordHistoryService(ChangePasswordHistoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ChangePasswordHistory>> Get()
        {
            return await _repository.Get();
        }
        public async Task<List<ChangePasswordHistory>> Get(long officerId)
        {
            return await _repository.Get(officerId);
        }
        public async Task<int> Delete(int month)
        {
            return await _repository.Delete(month);
        }

    }
}
