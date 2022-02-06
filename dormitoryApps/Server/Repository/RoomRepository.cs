using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class RoomRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "room";

        public RoomRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Room item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Room>(item);
            return res;
        }
        public async Task<bool> Update(Room item)
        {var res = await _databases.Dorm.UpdateEntityAsync<Room>(item, $"Id={item.Id}");
            return res == 1;
        }
        public async Task<bool> Delete(int roomId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"id={roomId}");
            return res == 1;
        }
        public async Task<List<Room>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Room>();
            return res.ToList();
        }
        public async Task<List<Room>> GetByBuilding(int buildingId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Room>(TableName, $"Building={buildingId}");
            return res.OrderBy(x => x.Floor).ToList();
        }
        public async Task<List<Room>> GetHasAircondition()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Room>(TableName, $"Aircond=1");
            return res.ToList();
        }
        public async Task<List<Room>> GetEnabled()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Room>(TableName, $"Enabled=1");
            return res.ToList();
        }
        public async Task<Room> GetById(int id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Room>(TableName, $"id={id}");
            return res.FirstOrDefault();
        }
    }
}
