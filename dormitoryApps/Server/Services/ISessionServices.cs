using dormitoryApps.Server.Repository;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;

namespace dormitoryApps.Server.Services
{
    public interface ISessionServices
    {
        Task<string> Createlogin(long userId);
        Task<bool> SetLogout(string SessionId);
        Task<bool> ForceLogout(long UserId);
        Task<List<Session>> Getall();
        Task<List<Session>> GetByUser(long UserId);
        int SuperForcedlogout(int day);
        int DeleteAfterMonth(int month);
        Task<Officer> GetCurrentlogin(string SessionId);
        Task<List<Session>> GetWithAdvanceSearch(SessionAdvancedSearchCriteria criteria);
    }
    public class SessionServices : ISessionServices
    {
        private readonly SessionRepository _Repository;

        public SessionServices(SessionRepository repository)
        {
            _Repository = repository;
        }
        public async Task<string> Createlogin(long userId)
        {
            return await _Repository.Createlogin(userId);
        }
        public async Task<bool> SetLogout(string SessionId)
        {
            return await _Repository.SetLogout(SessionId);
        }
        public async Task<bool> ForceLogout(long UserId)
        {
            return await _Repository.ForceLogout(UserId);
        }
        public async Task<List<Session>> Getall()
        {
            return await _Repository.Getall();
        }
        public async Task<List<Session>> GetByUser(long UserId)
        {
            return await _Repository.GetByUser(UserId);
        }
        public int SuperForcedlogout(int day)
        {
            return _Repository.SuperForcedlogout(day);
        }
        public int DeleteAfterMonth(int month)
        {
            return _Repository.DeleteAfterMonth(month);
        }
        public async Task<Officer> GetCurrentlogin(string SessionId)
        {
            return await _Repository.GetCurrentlogin(SessionId);
        }
        public async Task<List<Session>> GetWithAdvanceSearch(SessionAdvancedSearchCriteria criteria)
        {
            return await _Repository.GetWithAdvanceSearch(criteria);
        }
    }
}
