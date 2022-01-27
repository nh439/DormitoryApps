using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Server.Securites;

namespace dormitoryApps.Server.Services
{
    public interface IOfficerServices
    {
        Task<bool> Create(Officer item);
        Task<bool> Update(Officer item);
        Task<List<Officer>> Getall();
        Task<List<Officer>> GetExpired();
        Task<List<Officer>> GetNotExpired();
        Task<Officer> GetById(long Id);
        Task<bool> LoginCheck(string username, string password);

    }
    public class OfficerServices : IOfficerServices
    {
        private readonly OfficerRepository _repository;

        public OfficerServices(OfficerRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(Officer item)
        {
            PasswordHash hash = new PasswordHash();
            string password = item.Password;
            var salt = hash.CreateSalt();
            var phash = hash.CreateHash(password,salt);
            item.Password=Convert.ToBase64String(phash);
            item.Idx = Convert.ToBase64String(salt);
            item.Registerd = DateTime.Now;
            return await _repository.Create(item);
        }
        public async Task<bool> Update(Officer item)
        {
            return await _repository.Update(item);
        }
        public async Task<List<Officer>> Getall()
        {
            return await _repository.Getall();
        }
        public async Task<List<Officer>> GetExpired()
        {
            return await _repository.GetExpired();
        }
        public async Task<List<Officer>> GetNotExpired()
        {
            return await _repository.GetNotExpired();
        }
        public async Task<Officer> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }
        public async Task<bool> LoginCheck(string username, string password)
        {
            return await _repository.LoginCheck(username, password);
        }

    }
}
