using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class PastCustomerRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "pastcustomer";

        public PastCustomerRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(PastCustomer item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<PastCustomer>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable< PastCustomer> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<PastCustomer>(items);
            return res;
        }
        public async Task<bool> Update(PastCustomer item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<PastCustomer>(item,$"Id='{item.Id}'");
            return res==1;
        }
        public async Task<bool>Delete (string Id)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"Id='{Id}'");
            return res == 1;
        }
        public async Task<List<PastCustomer>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<PastCustomer>();
            return res.ToList();
        }
        public async Task<List<PastCustomer>> GetUnRefund()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<PastCustomer>(TableName, "Refunded=0");
            return res.ToList();
        }
        public async Task<PastCustomer> GetById(string Id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<PastCustomer>(TableName, $"Id='{Id}'");
            return res.FirstOrDefault();
        }
    }
}
