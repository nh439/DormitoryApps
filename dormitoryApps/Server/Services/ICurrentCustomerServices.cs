using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface ICurrentCustomerServices
    {
        Task<bool> Create(CurrentCustomer item);
        Task<bool> Update(CurrentCustomer item);
        Task<bool> Delete(string Id);
        Task<List<CurrentCustomer>> Getall();
        Task<List<CurrentCustomer>> GetByRoom(int roomId);
        Task<CurrentCustomer> GetById(string Id);
    }
    public class CurrentCustomerServices : ICurrentCustomerServices
    {
        private readonly CurrentCustomerRepository _repository;

        public CurrentCustomerServices(CurrentCustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(CurrentCustomer item)
        {
            return await _repository.Create(item);
        }
        public async Task<bool> Update(CurrentCustomer item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(string Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<List<CurrentCustomer>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<CurrentCustomer>> GetByRoom(int roomId)
        {
            return await _repository.GetByRoom(roomId);
        }
        public async Task<CurrentCustomer> GetById(string Id)
        {
            return await _repository.GetById(Id);
        }
    }
}
