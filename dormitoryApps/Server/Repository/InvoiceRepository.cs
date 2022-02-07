using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class InvoiceRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "invoice";
        public InvoiceRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Invoice item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Invoice>(item);
            return res;
        }
        public async Task<bool> Update(Invoice item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<Invoice>(item,$"Id={item.Id}");
            return res==1;
        }
        public async Task<bool> Delete(string InvoiceId)
        {
            DBDataContrainer data = new DBDataContrainer();
            data.ColumnName = "Iscancel";
            data.Value = true;
            var res = await _databases.Dorm.UpdateAsync(TableName, data, $"Id='{InvoiceId}'");
            return res == 1;
        }
        public async Task<List<Invoice>> GetAll()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>();
            return res.ToList();
        }
        public async Task<List<Invoice>> GetPaid()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>(TableName, "Ispaid=1");
            return res.ToList();
        }
        public async Task<List<Invoice>> GetUnPaid()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>(TableName, "Ispaid=0");
            return res.ToList();
        }
        public async Task<List<Invoice>> GetByYear(int year)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>(TableName, $"year={year}");
            return res.ToList();
        }
        public async Task<List<Invoice>> GetByMonth(int Month,int year)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>(TableName, $"year={year} and month={Month}");
            return res.ToList();
        }
        public async Task<List<Invoice>> GetByRental(string RentalId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>(TableName, $"RentalId='{RentalId}'");
            return res.ToList();
        }
        public async Task<Invoice> GetById(string InvoiceId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>(TableName, $"Id='{InvoiceId}'");
            return res.FirstOrDefault();
        }
        public async Task<List<Invoice>> GetWithAdvancesearch(InvoiceAdvancedSearchCriteria criteria)
        {
            ConditionSet set = new ConditionSet();
            if(!string.IsNullOrEmpty( criteria.RentalId))
            {
                set.Add("RentalId", criteria.RentalId, SqlOperator.Equal, SqlCondition.AND);
            }
            if(criteria.InvoiceDate.Min.HasValue)
            {
                set.Add("InvoiceDate", criteria.InvoiceDate.Min.Value.Date, SqlOperator.MoreThanOrEqual, SqlCondition.AND);
            }
            if(criteria.InvoiceDate.Max.HasValue)
            {
                set.Add("InvoiceDate", criteria.InvoiceDate.Max.Value.Date.AddDays(1), SqlOperator.LessThanOrEqual, SqlCondition.AND);
            }
            if(criteria.PaidDate.Min.HasValue)
            {
                set.Add("PaidDate", criteria.PaidDate.Min.Value.Date, SqlOperator.MoreThanOrEqual, SqlCondition.AND);
            }
            if(criteria.PaidDate.Max.HasValue)
            {
                set.Add("PaidDate", criteria.PaidDate.Max.Value.Date.AddDays(1), SqlOperator.LessThanOrEqual, SqlCondition.AND);
            }
            if(criteria.Month.HasValue)
            {
                set.Add("month", criteria.Month, SqlOperator.Equal, SqlCondition.AND);
            }
            if(criteria.Year.HasValue)
            {
                set.Add("Year", criteria.Year, SqlOperator.Equal, SqlCondition.AND);
            }
            if(criteria.InvoiceOfficer.HasValue)
            {
                set.Add("InvoiceOfficer", criteria.InvoiceOfficer, SqlOperator.Equal, SqlCondition.AND);
            }
            if(criteria.PaidOfficer.HasValue)
            {
                set.Add("PaidOfficer", criteria.PaidOfficer, SqlOperator.Equal, SqlCondition.AND);
            }
            if(!string.IsNullOrEmpty(criteria.PaidWith))
            {
                set.Add("Paidwith", criteria.PaidWith, SqlOperator.Equal, SqlCondition.AND);
            }
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>(TableName, set);
            return res.ToList();
        }


    }
}
