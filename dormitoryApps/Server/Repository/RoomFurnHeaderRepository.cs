using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class RoomFurnHeaderRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "roomfurnheader";

        public RoomFurnHeaderRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(RoomFurnHeader item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RoomFurnHeader>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable<RoomFurnHeader> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RoomFurnHeader>(items);
            return res;
        }
        public async Task<bool> Update(RoomFurnHeader item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<RoomFurnHeader>(item, $"Id={item.Id}");
            return res == 1;
        }
        public async Task<bool> Delete(long itemId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"Id={itemId}");
            return res == 1;
        }
        public async Task<int> DeleteByType(string itemType)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"Type='{itemType}'");
            return res;
        }
        public async Task<List<RoomFurnHeader>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomFurnHeader>();
            return res.ToList();
        }
        public async Task<List<RoomFurnHeader>> GetByType(string type)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomFurnHeader>(TableName, $"Type='{type}'");
            return res.ToList();
        }
        public async Task<RoomFurnHeader> GetById(long Id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomFurnHeader>(TableName, $"Id={Id}");
            return res.FirstOrDefault();
        }
        public async Task<string[]> GetTypes()
        {
            var res = await _databases.Dorm.SelectDistinctAsync(TableName, "Type");
            return res;
        }

    }
}
