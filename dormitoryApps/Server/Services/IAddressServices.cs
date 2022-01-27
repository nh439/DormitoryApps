using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IAddressServices
    {
        Task<bool> Create(Address item);
        Task<bool> Update(Address item);
        Task<Address> GetById(string Id);
        Task<List<Address>> GetIn(params string[] AddressIds);
    }
    public class AddressServices : IAddressServices
    {
        private readonly AddressRepository _repository;

        public AddressServices(AddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Address item)
        {
            return await _repository.Create(item);
        }
        public async Task<bool> Update(Address item)
        {
            return await _repository.Update(item);
        }
        public async Task<Address> GetById(string Id)
        {
            return await _repository.GetById(Id);
        }
        public async Task<List<Address>> GetIn(params string[] AddressIds)
        {
            return await _repository.GetIn(AddressIds);
        }

    }
}
