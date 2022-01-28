using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IBuildingsServices
    {
        Task<bool> Create(Buildings item);
        Task<bool> Update(Buildings item);
        Task<List<Buildings>> GetAll();
        Task<Buildings> GetById(int id);
    }
    public class BuildingsServices : IBuildingsServices
    {
        private readonly BuildingsRepository _repository;

        public BuildingsServices(BuildingsRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Buildings item)
        {
            return await _repository.Create(item);
        }
        public async Task<bool> Update(Buildings item)
        {
            return await _repository.Update(item);
        }
        public async Task<List<Buildings>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<Buildings> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
