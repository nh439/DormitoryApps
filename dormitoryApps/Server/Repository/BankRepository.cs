using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class BankRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "bank";
        public BankRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Bank item)
        {
            if(item.Id==9999)
            {
                throw new ArgumentException("Restricted Id");
            }
            var res = await _databases.Dorm.InsertEntitiesAsync<Bank>(item);
            return res;
        }
        public async Task<bool> Delete(int itemId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName,$"Id={itemId}");
            return res ==1;
        }
        public async Task<List<Bank>> Get()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Bank>();
            List<Bank> result = res != null ? res.ToList(): new List<Bank>();
            result.Add(new Bank { Id = 9999, Name = "อื่นๆ โปรดระบุ" });
            return result;

        }
        public async Task<Bank> Get(int Id)
        {
            if (Id == 9999) return new Bank { Id = Id, Name = "อื่นๆ โปรดระบุ" };
            var res = await _databases.Dorm.SelectEntitiesAsync<Bank>(TableName, $"Id={Id}");
            return res.FirstOrDefault();
        }

    }
}
