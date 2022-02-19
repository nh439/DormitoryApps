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


    }
}
