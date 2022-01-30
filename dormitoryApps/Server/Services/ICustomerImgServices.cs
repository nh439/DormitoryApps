using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface ICustomerImgServices
    {
        Task<bool> Create(CustomerImg item);
        Task<int> Create(IEnumerable<CustomerImg> items);
        Task<int> UpdateByRentalId(IEnumerable<CustomerImg> items, string RentalId);
        Task<int> DeleteByRentalId(string RentalId);
        Task<List<CustomerImg>> GetbyRentalId(string RentalId);
        Task<List<CustomerImg>> Getall();

    }
    public class CustomerImgServices:ICustomerImgServices
    {
        private readonly CustomerImgRepository _repository;
        public CustomerImgServices(CustomerImgRepository repository)
        {
            _repository= repository;
        }
        public async Task<bool> Create(CustomerImg item)
        {
            return await _repository.Create(item);
        }
        public async Task<int> Create(IEnumerable<CustomerImg> items)
        {
            return await _repository.Create(items);
        }
        public async Task<int> UpdateByRentalId(IEnumerable<CustomerImg> items, string RentalId)
        {
            return await _repository.UpdateByRentalId(items, RentalId);
        }
        public async Task<int> DeleteByRentalId(string RentalId)
        {
            return await _repository.DeleteByRentalId(RentalId);
        }
        public async Task<List<CustomerImg>> GetbyRentalId(string RentalId)
        {
            return await _repository.GetbyRentalId(RentalId);
        }
        public async Task<List<CustomerImg>> Getall()
        {
            return await _repository.Getall();
        }
    }
}
