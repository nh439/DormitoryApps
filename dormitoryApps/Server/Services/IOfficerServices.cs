using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Server.Securites;
using dormitoryApps.Shared.Model.Other;

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
        Task<Officer> GetByUsername(string Username);
        Task<int> PostitionDeleted(int PostitionId);
        Task<int> PostitionUpgrade(IEnumerable<NewPostitionParameter> items);
        Task<bool> GetExistUsername(string username);
        Task<bool> GetExistEmail(string Email);
        Task<bool> ExpiredOfficer(long officeId, string remark);
        Task<bool> RestoreOfficer(long officeId, bool resetRegisterDate);
        Task<bool> ChangePassword(long officerId, string newPassword, bool forgotMode);
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
        public async Task<Officer> GetByUsername(string Username)
        {
            return await _repository.GetByUsername(Username);
        }
        public async Task<int> PostitionDeleted(int PostitionId)
        {
            return await _repository.PostitionDeleted(PostitionId);
        }
        public async Task<int> PostitionUpgrade(IEnumerable<NewPostitionParameter> items)
        {
            return await _repository.PostitionUpgrade(items);
        }
        public async Task<bool> GetExistUsername(string username)
        {
            return await _repository.GetExistUsername(username);
        }
        public async Task<bool> GetExistEmail(string Email)
        {
            return await _repository.GetExistEmail(Email);
        }
        public async Task<bool> ExpiredOfficer(long officeId, string remark)
        {
            return await _repository.ExpiredOfficer(officeId, remark);
        }
        public async Task<bool> RestoreOfficer(long officeId, bool resetRegisterDate)
        {
            return await _repository.RestoreOfficer(officeId, resetRegisterDate);
        }
        public async Task<bool> ChangePassword(long officerId, string newPassword, bool forgotMode)
        {
            PasswordHash hash = new PasswordHash();
            var salt = hash.CreateSalt();
            var password = hash.CreateHash(newPassword, salt);
            return await _repository.ChangePassword(officerId, Convert.ToBase64String(password), Convert.ToBase64String(salt), forgotMode);
        }
    }
}
