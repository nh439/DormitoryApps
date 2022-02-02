using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
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
            var res = await _databases.Dorm.UpdateEntityAsync<Invoice>(item);
            return res;
        }
        public async Task<bool> Delete(long InvoiceId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"Id={InvoiceId}");
            return res == 1;
        }
        public async Task<List<Invoice>> GetAll()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>();
            return res.ToList();
        }
        public async Task<List<Invoice>> GetPaid()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>(TableName, "paid=1");
            return res.ToList();
        }
        public async Task<List<Invoice>> GetUnPaid()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>(TableName, "paid=0");
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
        public async Task<Invoice> GetById(long InvoiceId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Invoice>(TableName, $"Id={InvoiceId}");
            return res.FirstOrDefault();
        }


    }
}
