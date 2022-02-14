using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IPostitionChangedService
    {
        Task<bool> Create(PostitionChanged item);
        Task<List<PostitionChanged>> Getall();
        Task<List<PostitionChanged>> GetByofficer(long officerId);
    }
    public class PostitionChangedService : IPostitionChangedService
    {
        private readonly PostitionChangedRepository _repository;

        public PostitionChangedService(PostitionChangedRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(PostitionChanged item)
        {
            return await _repository.Create(item);
        }
        public async Task<List<PostitionChanged>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<PostitionChanged>> GetByofficer(long officerId)
        {
            return await _repository.GetByofficer(officerId);
        }
    }
}
