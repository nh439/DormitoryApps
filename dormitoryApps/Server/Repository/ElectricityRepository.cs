using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class ElectricityRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "electricity";

        public ElectricityRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Electricity item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Electricity>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable<Electricity> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Electricity>(items);
            return res;
        }
        public async Task<bool> Update (Electricity item)
        {
            ConditionSet set = new ConditionSet();
            set.Add("RentalId", item.RentalId, SqlOperator.Equal, SqlCondition.AND);
            set.Add("month", item.month, SqlOperator.Equal, SqlCondition.AND);
            set.Add("Year", item.Year, SqlOperator.Equal, SqlCondition.AND);
            var res =await _databases.Dorm.UpdateEntityAsync<Electricity>(item, set);
            return res == 1;
        }
        public async Task<bool> Delete(string rentalId,int month,int year)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"RentalId='{rentalId}' and month = {month} and year={year}");
            return res == 1;
        }
        public async Task<List<Electricity>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Electricity>();
            return res.ToList();
        }
        public async Task<List<Electricity>> GetByRentalId(string rentalId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Electricity>(TableName, $"rentalId='{rentalId}'");
            return res.ToList();
        }
        public async Task<List<Electricity>> GetPaid()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Electricity>(TableName, $"paid=1");
            return res.ToList();
        }
          public async Task<List<Electricity>> GetUnPaid()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Electricity>(TableName, $"paid=0");
            return res.ToList();
        }
        public async Task<List<Electricity>> GetByYear(int year)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Electricity>(TableName, $"year={year}");
            return res.ToList();
        }
        public async Task<List<Electricity>> GetByMonth(int year,int month)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Electricity>(TableName, $"year={year} and month={month}");
            return res.ToList();
        }
        public async Task<Electricity> Getone(string RentalId,int month,int year)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Electricity>(TableName, $"RentalId='{RentalId}' and year={year} and month={month}");
            return res.FirstOrDefault();
        }

    }
}
