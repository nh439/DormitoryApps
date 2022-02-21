using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class RoomFurnHeaderValuesRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "roomfurnheadervalues";
        public RoomFurnHeaderValuesRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(RoomFurnHeaderValues item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RoomFurnHeaderValues>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable<RoomFurnHeaderValues> values)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RoomFurnHeaderValues>(values);
            return res;
        }
        public async Task<bool> Update(RoomFurnHeaderValues item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<RoomFurnHeaderValues>(item, $"Id={item.Id}");
            return res == 1;
        }
        public async  Task<bool> Delete(long Id)
        {
            
            var res = await _databases.Dorm.DeleteAsync(TableName,$"Id={Id}");
            return res==1;
        }
        public async  Task<int> DeleteByHeader(long headerId)
        {
            
            var res = await _databases.Dorm.DeleteAsync(TableName,$"HeaderId={headerId}");
            return res;
        }
        public async Task< List<RoomFurnHeaderValues>> Getall()
        {
            var res= await _databases.Dorm.SelectEntitiesAsync<RoomFurnHeaderValues>();
            return res.ToList();
        }
        public async Task<List<RoomFurnHeaderValues>> GetByHeader(long HeaderId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomFurnHeaderValues>(TableName,$"HeaderId={HeaderId}");
            return res.ToList();
        }
        public async Task<RoomFurnHeaderValues> GetById(long Id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomFurnHeaderValues>(TableName,$"Id={Id}");
            return res.FirstOrDefault();
        }

    }
}
