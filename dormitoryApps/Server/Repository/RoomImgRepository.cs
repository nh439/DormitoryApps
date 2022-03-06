using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class RoomImgRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "roomImg";
        public RoomImgRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(RoomImg item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RoomImg>(item);
            return res;
        } 
        public async Task<int> Create(IEnumerable<RoomImg> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RoomImg>(items);
            return res;
        }
        public async Task<bool> Update(RoomImg item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<RoomImg>(item,$"Id={item.Id}");
            return res==1;
        }
        public async Task<bool> UpdateCommit(IEnumerable<RoomImg> items)
        {
            bool res = false;
            await DeleteByRoom(items.FirstOrDefault().RoomId);
            await Create(items);
            res = true;
            return res;

        }
        public async Task<bool> Delete(long Id)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName,$"Id={Id}");
            return res==1;
        }
        public async Task<int> DeleteByRoom(int roomId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName,$"RoomId={roomId}");
            return res;
        }
        public async Task<RoomImg> GetByRoom(int roomId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomImg>(TableName, $"RoomId={roomId}");
            return res.FirstOrDefault();
        }
        public async Task<List<RoomImg>> GetById(long Id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomImg>(TableName, $"Id={Id}");
            return res.ToList();
        }

    }
}
