using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class MyServiceRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "MyServices";
        public MyServiceRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(MyServices item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<MyServices>(item);
            return res;
        }
        public async Task<bool> Update(MyServices item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<MyServices>(item,$"Id={item.Id}");
            return res==1;
        }
        public async Task<bool> Delete(long itemId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName,$"Id={itemId}");
            return res==1;
        }
        public async Task<List<MyServices>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<MyServices>();
            return res.OrderBy(x => x.Id).OrderBy(x=>(x.Enabled==true)).ToList();
        }
        public async Task<MyServices> GetById(long Id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<MyServices>(TableName, $"Id={Id}");
            return res.FirstOrDefault();
        }

    }
}
