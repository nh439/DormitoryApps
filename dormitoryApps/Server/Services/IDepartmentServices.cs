using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IDepartmentServices
    {
        Task<bool> Create(Department item);
        Task<bool> Update(Department item);
        Task<List<Department>> Getall();
        Task<Department> GetById(int departmantId);
    }
    public class DepartmentService : IDepartmentServices
    {
        private readonly DepartmentRepository _repository;

        public DepartmentService(DepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Department item)
        {
            return await _repository.Create(item);
        }
        public async Task<bool> Update(Department item)
        {
            return await _repository.Update(item);
        }
        public async Task<List<Department>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<Department> GetById(int departmantId)
        {
            return await _repository.GetById(departmantId);
        }
    }
}
