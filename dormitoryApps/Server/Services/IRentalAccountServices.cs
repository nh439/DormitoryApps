using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IRentalAccountServices
    {
        Task<bool> Create(RentalAccount item);
        Task<bool> Update(RentalAccount item);
        Task<bool> Delete(string accountId);
        Task<RentalAccount> Get(string accountId);
    }
    public class RentalAccountServices:IRentalAccountServices
    {
        private readonly RentalAccountRepository _repository;

        public RentalAccountServices(RentalAccountRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(RentalAccount item)
        {
            return await _repository.Create(item);
        }
        public async Task<bool> Update(RentalAccount item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> Delete(string accountId)
        {
            return await _repository.Delete(accountId);
        }
        public async Task<RentalAccount> Get(string accountId)
        {
            return await _repository.Get(accountId);
        }

    }
}
