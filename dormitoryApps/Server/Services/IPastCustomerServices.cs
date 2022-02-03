using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IPastCustomerServices
    {
        Task<bool> Create(PastCustomer item);
        Task<int> Create(IEnumerable<PastCustomer> items);
        Task<bool> Update(PastCustomer item);
        Task<bool> Delete(long Id);
        Task<List<PastCustomer>> Getall();
        Task<List<PastCustomer>> GetByRental(string RentalId);
        Task<List<PastCustomer>> GetUnRefund();
        Task<PastCustomer> GetById(long Id);
    }
    public class PastCustomerServices : IPastCustomerServices
    {
        private readonly PastCustomerRepository _repository;

        public PastCustomerServices(PastCustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(PastCustomer item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<PastCustomer> items)
        {
            return await _repository.Create(items);
        }
        public async Task<bool> Update(PastCustomer item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(long Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<List<PastCustomer>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<PastCustomer>> GetByRental(string RentalId)
        {
            return await _repository.GetByRental(RentalId);
        }
        public async Task<List<PastCustomer>> GetUnRefund()
        {
            return await _repository.GetUnRefund();
        }
        public async Task<PastCustomer> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }


    }
}
