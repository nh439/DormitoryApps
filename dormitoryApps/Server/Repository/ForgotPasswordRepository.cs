using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class ForgotPasswordRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "forgotpassword";

        public ForgotPasswordRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(ForgotPassword item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<ForgotPassword>(item);
            return res;
        }
        public async Task<ForgotPassword> GetById(long Id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<ForgotPassword>(TableName, $"Id={Id}");
            return res.FirstOrDefault();
        }
        public async Task<ForgotPassword> GetByToken(string Token,long UserId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<ForgotPassword>(TableName, $"Token='{Token}' and UserId={UserId}");
            return res.FirstOrDefault();
        }
        public async Task<bool> TokenCheck(string Token,long UserId)
        {
            bool result = false;
            var queryRes = await _databases.Dorm.SelectEntitiesAsync<ForgotPassword>(TableName, $"Token='{Token}' and UserId={UserId}");
            if(result != null)
            {
                var item = queryRes.FirstOrDefault();
                result = !item.Expired && DateTime.Now.Subtract(item.ExpiredAt).TotalSeconds <= 0;
            }
            return result;
        }
        public async Task<ForgotPassword> PasswordCheck(int Password,long UserId)
        {
            var result = await _databases.Dorm.SelectEntitiesAsync<ForgotPassword>(TableName, $"UserId={UserId} and Password={Password}");
            return result.FirstOrDefault();
        }
        public async Task<int> Delete()
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"Expired=1");
            return res;
        }


    }
}
