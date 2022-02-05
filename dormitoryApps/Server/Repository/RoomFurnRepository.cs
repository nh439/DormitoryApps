using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class RoomFurnRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "roomfurn";
        public RoomFurnRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(RoomFurn item)
        {
            var res= await _databases.Dorm.InsertEntitiesAsync<RoomFurn>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable<RoomFurn> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RoomFurn>(items);
            return res;
        }
        public async Task<bool> Update(RoomFurn item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<RoomFurn>(item);
            return res;
        }
        public async Task<bool> Delete(long Id)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"Id={Id}");
            return res==1;
        }
        public async Task<int> DeleteRoom(int RoomId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"RoomId={RoomId}");
            return res;
        }
        public async Task<List<RoomFurn>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomFurn>();
            return res.OrderBy(x=>x.Id).OrderBy(x=>x.RoomId).ToList();
        }
        public async Task<bool> UpdateRoom(IEnumerable<RoomFurn> items)
        {
            bool res = false;
            await _databases.Dorm.DeleteAsync(TableName, $"RoomId={ items.FirstOrDefault().RoomId}");
            await _databases.Dorm.InsertEntitiesAsync<RoomFurn>(items);
            res = true;
            return res;

        }
        public async Task<List<RoomFurn>> GetByRoom(int RoomId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomFurn>(TableName, $"RoomId={RoomId}");
            return res.ToList();
        }
        public async Task<RoomFurn> GetById(long Id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomFurn>(TableName, $"Id={Id}");
            return res.FirstOrDefault();
        }
    }
}
