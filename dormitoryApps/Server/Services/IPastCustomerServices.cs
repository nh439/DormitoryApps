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
        private readonly IRentalMemberServices _rentalMemberServices;

        public PastCustomerServices(PastCustomerRepository repository, 
            IRentalMemberServices rentalMemberServices)
        {
            _repository = repository;
            _rentalMemberServices = rentalMemberServices;

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
        public async Task<bool> Delete(string Id)
        {
            return await _repository.Delete(Id);
        }
        public async Task<List<PastCustomer>> Getall()
        {
            var res = await _repository.Getall();
            res.ForEach(async x =>
            {
                x.Members = await _rentalMemberServices.GetByRentalId(x.Id);
            });
            return res;
        }     
        public async Task<List<PastCustomer>> GetUnRefund()
        {
            var res= await _repository.GetUnRefund();
            res.ForEach(async x =>
            {
                x.Members = await _rentalMemberServices.GetByRentalId(x.Id);
            });
            return res;
        }
        public async Task<PastCustomer> GetById(string Id)
        {
            var res= await _repository.GetById(Id);
            if (res != null) res.Members = await _rentalMemberServices.GetByRentalId(Id);
            return res;
        }
        public async Task<string[]> GetIds()
        {
            return await _repository.GetIds();
        }


    }
}
