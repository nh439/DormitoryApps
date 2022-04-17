using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IBankServices
    {
        Task<bool> Create(Bank item);
        Task<bool> Delete(int itemId);
        Task<List<Bank>> Get();
        Task<Bank> Get(int Id);
    }
    public class BankServices : IBankServices
    {
        private readonly BankRepository _repository;

        public BankServices(BankRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Bank item)
        {
            return await _repository.Create(item);
        }
        public async Task<bool> Delete(int itemId)
        {
            return await _repository.Delete(itemId);
        }
        public async Task<List<Bank>> Get()
        {
            return await _repository.Get();
        }
        public async Task<Bank> Get(int Id)
        {
            return await _repository.Get(Id);
        }

    }
}
