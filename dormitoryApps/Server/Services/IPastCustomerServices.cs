using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IPastCustomerServices
    {
        Task<bool> Create(PastCustomer item);
        Task<int> Create(IEnumerable<PastCustomer> items);
        Task<bool> Update(PastCustomer item);
        Task<bool> Delete(string Id);
        Task<List<PastCustomer>> Getall();
        Task<List<PastCustomer>> GetUnRefund();
        Task<PastCustomer> GetById(string Id);
        Task<string[]> GetIds();
    }
    public class PastCustomerServices : IPastCustomerServices
    {
        private readonly PastCustomerRepository _repository;
        private readonly RentalAccountRepository _accountRepository;
        private readonly IRentalMemberServices _rentalMemberServices;

        public PastCustomerServices(PastCustomerRepository repository,
            IRentalMemberServices rentalMemberServices, 
            RentalAccountRepository accountRepository)
        {
            _repository = repository;
            _rentalMemberServices = rentalMemberServices;
            _accountRepository = accountRepository;

        }
        public async Task<bool> Create(PastCustomer item)
        {
            var res = await _repository.Create(item);
            if(res && item.Account != null && item.Account != new RentalAccount())
            {
                item.Account.RentalId = item.Id;
                await _accountRepository.Create(item.Account);
            }
            return res;
        }
        public async Task<int> Create(IEnumerable<PastCustomer> items)
        {
            var res = await _repository.Create(items);
            foreach(var item in items)
            {
                if(item.Account != null && item.Account != new RentalAccount())
                {
                    var account = item.Account;
                    account.RentalId = item.Id;
                    await _accountRepository.Create(account);
                }
            }
            return res;
        }
        public async Task<bool> Update(PastCustomer item)
        {
            var res = await _repository.Update(item);
            await _accountRepository.Delete(item.Id);
            await Task.Delay(10);
            if(item.Account != null && item.Account != new RentalAccount())
            {
                await _accountRepository.Create(item.Account);
            }
            return res;
        }
        public async Task<bool> Delete(string Id)
        {
            await _accountRepository.Delete(Id);
            return await _repository.Delete(Id);
        }
        public async Task<List<PastCustomer>> Getall()
        {
            var res = await _repository.Getall();
            res.ForEach(async x =>
            {
                x.Members = await _rentalMemberServices.GetByRentalId(x.Id);
            });
            await Task.Delay(100);
            return res;
        }     
        public async Task<List<PastCustomer>> GetUnRefund()
        {
            var res= await _repository.GetUnRefund();
            res.ForEach(async x =>
            {
                x.Members = await _rentalMemberServices.GetByRentalId(x.Id);
            });
            await Task.Delay(100);
            return res;
        }
        public async Task<PastCustomer> GetById(string Id)
        {
            var res= await _repository.GetById(Id);
            if (res != null)
            { 
                res.Members = await _rentalMemberServices.GetByRentalId(Id);
                res.Account = await _accountRepository.Get(Id);
            }
            return res;
        }
        public async Task<string[]> GetIds()
        {
            return await _repository.GetIds();
        }


    }
}
