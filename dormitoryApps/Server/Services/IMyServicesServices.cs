using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IMyServicesServices
    {
        Task<bool> Create(MyServices item);
        Task<bool> Update(MyServices item);
        Task<bool> Delete(long itemId);
        Task<List<MyServices>> Getall();
        Task<MyServices> GetById(long Id);
    }
    public class MyServicesServices : IMyServicesServices
    {
        private readonly MyServiceRepository _repository;

        public MyServicesServices(MyServiceRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(MyServices item)
        {
            return await _repository.Create(item);
        }
        public async Task<bool> Update(MyServices item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(long itemId)
        {
            return await _repository.Delete(itemId);
        }
        public async Task<List<MyServices>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<MyServices> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }
    }
}
