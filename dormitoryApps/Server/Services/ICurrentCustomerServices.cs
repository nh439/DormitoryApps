using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface ICurrentCustomerServices
    {
        Task<string> Create(CurrentCustomer item);
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
        private readonly IRentalMemberServices _rentalMemberServices;

        public CurrentCustomerServices(CurrentCustomerRepository repository,
            CustomerImgRepository customerImgRepository, 
            IRentalMemberServices rentalMemberServices)
        {
            _repository = repository;
            _customerImgRepository = customerImgRepository;
            _rentalMemberServices = rentalMemberServices;

        }
        public async Task<string> Create(CurrentCustomer item)
        {
            item.Id = _repository.GenerateId();
            var res = await _repository.Create(item);
            if(string.IsNullOrEmpty(res)) return string.Empty;
            if(item.Imgs != null)
            {
                item.Imgs.ForEach(x => x.RentalId = item.Id);
                await _customerImgRepository.Create(item.Imgs);
            }
            if(item.Members != null)
            {
                item.Members.ForEach(x => { x.RentalId=item.Id; });
                await _rentalMemberServices.Create(item.Members);
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
            if(res!=null)
            {
                foreach(var x in res)
                {
                    x.Imgs = Imgs.Where(z => z.RentalId == x.Id).ToList();
                    x.Members = await _rentalMemberServices.GetByRentalId(x.Id);
                }
            }
            return res;        
        }
        public async Task<List<CurrentCustomer>> GetByRoom(int roomId)
        {
            List<CurrentCustomer> result =new List<CurrentCustomer>();
            await _repository.GetByRoom(roomId).ContinueWith( async x =>
            {
                result = await x;
                if(result != null)
                {
                    result.ForEach(async y =>
                    {
                        y.Members = await _rentalMemberServices.GetByRentalId(y.Id);
                        y.Imgs = await _customerImgRepository.GetbyRentalId(y.Id);
                    });
                }
            });
            return result;
        }
        public async Task<CurrentCustomer> GetById(string Id)
        {
            var res= await _repository.GetById(Id);
            res.Members = await _rentalMemberServices.GetByRentalId(res.Id);
            res.Imgs = await _customerImgRepository.GetbyRentalId(res.Id);
            return res;
        }
    }
}
