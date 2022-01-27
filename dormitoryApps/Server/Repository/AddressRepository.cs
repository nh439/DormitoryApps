using RocketSQL;
using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class AddressRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "address";
        public AddressRepository (DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Address item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Address>(item);
            return res;
        }
        public async Task<bool> Update(Address item)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id",item.Id);
            var res = await _databases.Dorm.UpdateEntityAsync<Address>(item, set);
            return res == 1;
        }
        public async Task<Address> GetById(string Id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Address>(TableName, $"Id='{Id}'");
            return res.FirstOrDefault();
        }
        public async Task<List<Address>> GetIn(params string[] AddressIds)
        {
            ConditionSet set = new ConditionSet();
            set.AddIn("Id", AddressIds);
            var res = await _databases.Dorm.SelectEntitiesAsync<Address>(TableName, set);
            return res.ToList();
        }

    }
}
