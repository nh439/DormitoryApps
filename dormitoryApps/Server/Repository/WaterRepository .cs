using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class WaterRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "water";

        public WaterRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Water item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Water>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable<Water> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Water>(items);
            return res;
        }
        public async Task<bool> Update (Water item)
        {
            ConditionSet set = new ConditionSet();
            set.Add("RentalId", item.RentalId, SqlOperator.Equal, SqlCondition.AND);
            set.Add("month", item.month, SqlOperator.Equal, SqlCondition.AND);
            set.Add("Year", item.Year, SqlOperator.Equal, SqlCondition.AND);
            var res =await _databases.Dorm.UpdateEntityAsync<Water>(item, set);
            return res == 1;
        }
        public async Task<bool> Delete(string rentalId,int month,int year)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"RentalId='{rentalId}' and month = {month} and year={year}");
            return res == 1;
        }
        public async Task<List<Water>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Water>();
            return res.ToList();
        }
        public async Task<List<Water>> GetByRentalId(string rentalId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Water>(TableName, $"rentalId='{rentalId}'");
            return res.ToList();
        }
        public async Task<List<Water>> GetPaid()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Water>(TableName, $"paid=1");
            return res.ToList();
        }
          public async Task<List<Water>> GetUnPaid()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Water>(TableName, $"paid=0");
            return res.ToList();
        }
        public async Task<List<Water>> GetByYear(int year)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Water>(TableName, $"year={year}");
            return res.ToList();
        }
        public async Task<List<Water>> GetByMonth(int year,int month)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Water>(TableName, $"year={year} and month={month}");
            return res.ToList();
        }
        public async Task<Water> Getone(string RentalId,int month,int year)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Water>(TableName, $"RentalId='{RentalId}' and year={year} and month={month}");
            return res.FirstOrDefault();
        }
        public async Task<Water> GetByInvoiceId(string invoiceId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Water>(TableName, $"InvoiceId='{invoiceId}'");
            return res.FirstOrDefault();
        }
        public async Task<List<Water>> GetWithAdvanceSearch(ElectricityAndWaterAdvancedSearchCriteria  criteria)
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
            var res = await _databases.Dorm.SelectEntitiesAsync<Water>(TableName, set);
            return res.ToList();

        }

    }
}
