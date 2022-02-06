using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class InvoiceServiceRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "invoiceservice";

        public InvoiceServiceRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(InvoiceService item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<InvoiceService>(item);
            return res;
        } 
        public async Task<int> Create(IEnumerable<InvoiceService> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<InvoiceService>(items);
            return res;
        }
        public async Task<bool> Update(InvoiceService item)
        {
            ConditionSet set = new ConditionSet();
            set.Add("InvoiceId", item.InvoiceId, SqlOperator.Equal, SqlCondition.AND);
            set.Add("ServiceId", item.ServiceId, SqlOperator.Equal, SqlCondition.AND);
            var res = await _databases.Dorm.UpdateEntityAsync<InvoiceService>(item,set);
            return res==1;
        }
        public async Task<bool> Delete(InvoiceService item)
        {
            var res = await _databases.Dorm.DeleteEntitesAsync<InvoiceService>(item);
            return res;
        }
        public async Task<List<InvoiceService>> GetByInvoice(string invoiceId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<InvoiceService>(TableName, $"InvoiceId='{invoiceId}'");
            return res.ToList();
        }
         public async Task<List<InvoiceService>> GetByService(long serviceId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<InvoiceService>(TableName, $"InvoiceId='{serviceId}'");
            return res.ToList();
        }

    }
}
