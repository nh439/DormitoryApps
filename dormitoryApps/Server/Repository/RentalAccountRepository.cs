using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class RentalAccountRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "rentalaccount";
        public RentalAccountRepository(DBConnection databases)
        {
            _databases = databases; 
        }
        public async Task<bool> Create(RentalAccount item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RentalAccount>(item);
            return res;
        }
        public async Task<bool> Update(RentalAccount item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<RentalAccount>(item,$"RentalId='{item.RentalId}'");
            return res==1;
        }
        public async Task<bool> Delete(string accountId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"RentalId='{accountId}'");
            return res == 1;
        }
        public async Task<RentalAccount> Get(string accountId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RentalAccount>(TableName,$"RentalId='{accountId}'");
            return res.FirstOrDefault();
        }
    }
}
