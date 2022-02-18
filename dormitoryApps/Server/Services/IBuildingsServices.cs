using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IBuildingsServices
    {
        Task<bool> Create(Buildings item);
        Task<bool> Update(Buildings item);
        Task<List<Buildings>> GetAll();
        Task<Buildings> GetById(int id);
    }
    public class BuildingsServices : IBuildingsServices
    {
        private readonly BuildingsRepository _repository;
        private readonly AddressRepository _addressRepository;

        public BuildingsServices(BuildingsRepository repository, AddressRepository addressRepository)
        {
            _repository = repository;
            _addressRepository = addressRepository;
        }
        public async Task<bool> Create(Buildings item)
        {
            var res = await _repository.Create(item);
            if (item.MyAddress != null)
            {
                item.MyAddress.Id = item.Location;
                await _addressRepository.Create(item.MyAddress);
            }
            return res;
        }
        public async Task<bool> Update(Buildings item)
        {
            var res= await _repository.Update(item);
            if(res)
            {
                await _addressRepository.Update(item.MyAddress);
            }
            return res;
        }
        public async Task<List<Buildings>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<Buildings> GetById(int id)
        {
            var res = await _repository.GetById(id);
            res.MyAddress = await _addressRepository.GetById(res.Location);
            return res;
        }
    }
}
