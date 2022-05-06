using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class ChangePasswordHistoryRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "changepasswordhistory";
        public ChangePasswordHistoryRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<List<ChangePasswordHistory>> Get()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<ChangePasswordHistory>();
            return res.OrderByDescending(x=>x.ChangeAt).ToList();
        }
        public async Task<List<ChangePasswordHistory>> Get(long officerId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<ChangePasswordHistory>(TableName,$"UserId={officerId}");
            return res.OrderByDescending(x=>x.ChangeAt).ToList();
        }
        public async Task<int> Delete(int month)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"TIMESTAMPDIFF(month,ChangeAt,current_timestamp())>={month}");
            return res;
        }
    }
}
