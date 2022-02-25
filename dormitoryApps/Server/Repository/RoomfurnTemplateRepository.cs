using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class RoomfurnTemplateRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "roomfurntemplate";
        public RoomfurnTemplateRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(RoomfurnTemplate template)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RoomfurnTemplate>(template);
            return res;
        }
        public async Task<int> Create(IEnumerable<RoomfurnTemplate> templates)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RoomfurnTemplate>(templates);
            return res;
        }
        public async Task<bool> Update(RoomfurnTemplate template)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<RoomfurnTemplate>(template,$"Id={template.Id}");
            return res == 1;
        }
        public async Task<bool> Delete(long Id)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName,$"Id={Id}");
            return res == 1;
        }
        public async Task<int> DeleteTemplate(int roomId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName,$"RoomId={roomId}");
            return res;
        }
        public async Task<List<RoomfurnTemplate>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomfurnTemplate>();
            return res.ToList();
        }
        public async Task<List<RoomfurnTemplate>> GetByRoomId(int roomId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomfurnTemplate>(TableName,$"RoomId={roomId}");
            return res.ToList();
        }
        public async Task<List<RoomfurnTemplate>> GetByType(string typeName)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomfurnTemplate>(TableName,$"Type='{typeName}'");
            return res.ToList();
        }
        public async Task<RoomfurnTemplate> GetById(long id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomfurnTemplate>(TableName, $"Id={id}");
            return res.FirstOrDefault();
        }

    }
}
