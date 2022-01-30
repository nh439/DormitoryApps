using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface ICurrentCustomerServices
    {
        Task<bool> Create(CurrentCustomer item);
        Task<bool> Update(CurrentCustomer item);
        Task<bool> UpdateWithImg(CurrentCustomer item);
        Task<bool> Delete(string Id);
        Task<List<CurrentCustomer>> Getall();
        Task<List<CurrentCustomer>> GetByRoom(int roomId);
        Task<CurrentCustomer> GetById(string Id);
    }
    public class CurrentCustomerServices : ICurrentCustomerServices
    {
        private readonly CurrentCustomerRepository _repository;
        private readonly CustomerImgRepository _customerImgRepository;

        public CurrentCustomerServices(CurrentCustomerRepository repository, CustomerImgRepository customerImgRepository)
        {
            _repository = repository;
            _customerImgRepository = customerImgRepository;
        }
        public async Task<bool> Create(CurrentCustomer item)
        {
            var res = await _repository.Create(item);
            if(item.Imgs != null)
            {
                item.Imgs.ForEach(x => x.RentalId = item.Id);
                await _customerImgRepository.Create(item.Imgs);
            }
            return res;
        }
        public async Task<bool> Update(CurrentCustomer item)
        {
            return await _repository.Update(item);
        }
        public async Task<bool> UpdateWithImg(CurrentCustomer item)
        {
            var res =  await _repository.Update(item);
            await _customerImgRepository.UpdateByRentalId(item.Imgs, item.Id);
            return res;
        }
        public async Task<bool> Delete(string Id)
        {
            
            return await _repository.Delete(Id);
        }
        public async Task<List<CurrentCustomer>> Getall()
        {
            var Imgs =await _customerImgRepository.Getall();
            var res =  await _repository.Getall();
            res.ForEach(x => { x.Imgs = Imgs.Where(z => z.RentalId == x.Id).ToList(); });
            return res;        
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
