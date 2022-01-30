using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class CustomerImgRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "CustomerImg";

        public CustomerImgRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(CustomerImg item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<CustomerImg>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable<CustomerImg> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<CustomerImg>(items);
            return res;
        }
        public async Task<int> UpdateByRentalId(IEnumerable<CustomerImg> items, string RentalId)
        {
            await _databases.Dorm.DeleteAsync(TableName, $"RentalId='{RentalId}'");
            List<CustomerImg> imgs = items.ToList();
            imgs.ForEach(x => x.RentalId = RentalId);
            var res = await _databases.Dorm.InsertEntitiesAsync<CustomerImg>(imgs);
            return res;
        }
        public async Task<int> DeleteByRentalId(string RentalId)
        {
            return await _databases.Dorm.DeleteAsync(TableName, $"RentalId='{RentalId}'");
        }
        public async Task<List<CustomerImg>> GetbyRentalId(string RentalId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<CustomerImg>(TableName, $"RentalId='{RentalId}'");
            return res.ToList();
        }
        public async Task<List<CustomerImg>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<CustomerImg>();
            return res.ToList();
        }
    }
}
