using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IPostitionServices
    {
        Task<bool> Create(Postition item);
        Task<int> Create(IEnumerable<Postition> items);
        Task<bool> Update(Postition item);
        Task<bool> Deleted(int Id);
        Task<List<Postition>> Getall();
        Task<List<Postition>> GetByPostitionLine(int lineId);
        Task<List<Postition>> GetByDepartment(int DepartmentId);
        Task<Postition> GetById(int Id);
    }
    public class PostitionServices : IPostitionServices
    {
        private readonly PostitionRepository _repository;
        private readonly OfficerRepository _officerRepository;

        public PostitionServices(PostitionRepository repository,OfficerRepository officerRepository)
        {
            _repository = repository;
            _officerRepository = officerRepository;
        }
        public async Task<bool> Create(Postition item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<Postition> items)
        {
            return await _repository.Create(items);
        }
        public async Task<bool> Update(Postition item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Deleted(int Id)
        {
            await _officerRepository.PostitionDeleted(Id);
            return await _repository.Deleted(Id);
        }
        public async Task<List<Postition>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<Postition>> GetByPostitionLine(int lineId)
        {
            return await _repository.GetByPostitionLine(lineId);
        }
        public async Task<List<Postition>> GetByDepartment(int DepartmentId)
        {
            return await _repository.GetByDepartment(DepartmentId);
        }
        public async Task<Postition> GetById(int Id)
        {
            return await _repository.GetById(Id);
        }
    }
}
