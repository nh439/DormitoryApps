using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Services
{
    public interface IForgotPasswordServices
    {
        Task<bool> Create(ForgotPassword item);
        Task<ForgotPassword> GetById(long Id);
        Task<ForgotPassword> GetByToken(string Token, long UserId);
        Task<bool> TokenCheck(string Token, long UserId);
        Task<int> Delete();
    }
    public class ForgotPasswordServices : IForgotPasswordServices
    {
        private readonly ForgotPasswordRepository _repository;
        
        public ForgotPasswordServices(ForgotPasswordRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Create(ForgotPassword item)
        {
            return await _repository.Create(item);
        }
        public async Task<ForgotPassword> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }
        public async Task<ForgotPassword> GetByToken(string Token, long UserId)
        {
            return await _repository.GetByToken(Token, UserId);
        }
        public async Task<bool> TokenCheck(string Token, long UserId)
        {
            return await _repository.TokenCheck(Token, UserId);
        }
        public async Task<int> Delete()
        {
            return await _repository.Delete();
        }
    }
}
