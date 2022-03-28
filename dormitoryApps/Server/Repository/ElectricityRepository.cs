using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
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
        public async Task<Electricity> GetByInvoiceId(string invoiceId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Electricity>(TableName, $"InvoiceId='{invoiceId}'");
            return res.FirstOrDefault();
        }
        public async Task<List<Electricity>> GetWithAdvanceSearch(ElectricityAndWaterAdvancedSearchCriteria  criteria)
        {
            ConditionSet set = new ConditionSet();
            if(criteria.Haspaid.HasValue)
            {
                set.Add("Paid", criteria.Haspaid.Value, SqlOperator.Equal, SqlCondition.AND);
            }
            if(criteria.MinYear.HasValue)
            {
                set.Add("year", criteria.MinYear.Value, SqlOperator.LessThanOrEqual, SqlCondition.AND);
            }
            if (criteria.MaxYear.HasValue)
            {
                set.Add("year", criteria.MaxYear.Value, SqlOperator.MoreThanOrEqual, SqlCondition.AND);
            }
            if(criteria.MinMonth.HasValue)
            {
                set.Add("month", criteria.MinMonth.Value, SqlOperator.LessThanOrEqual, SqlCondition.AND);
            }
            if (criteria.MaxMonth.HasValue)
            {
                set.Add("month", criteria.MaxMonth.Value, SqlOperator.MoreThanOrEqual, SqlCondition.AND);
            }
            if(criteria.NotedateMin.HasValue)
            {
                set.Add("Notedate", criteria.NotedateMin.Value.Date, SqlOperator.LessThanOrEqual,SqlCondition.AND);
            }
             if(criteria.NotedateMax.HasValue)
            {
                set.Add("Notedate", criteria.NotedateMax.Value.Date.AddDays(1), SqlOperator.MoreThanOrEqual,SqlCondition.AND);
            }
            if(criteria.UnitPrice.HasValue)
            {
                set.Add("Price", criteria.UnitPrice, SqlOperator.Equal);
            }
            var res = await _databases.Dorm.SelectEntitiesAsync<Electricity>(TableName, set);
            return res.ToList();

        }

    }
}
