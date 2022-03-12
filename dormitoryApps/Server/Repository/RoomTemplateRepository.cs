using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class RoomTemplateRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "roomtemplate";

        public RoomTemplateRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(RoomTemplate template)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RoomTemplate>(template);
            return res;
        }
        public async Task<bool> Update(RoomTemplate template)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<RoomTemplate>(template,$"Id={template.Id}");
            return res==1;
        }
        public async Task<bool> Delete(int templateId)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName,$"Id={templateId}");
            return res==1;
        }
        public async Task<List<RoomTemplate>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomTemplate>();
            return res.ToList();
        }
        public async Task<RoomTemplate> GetById(int Id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomTemplate>(TableName,$"Id={Id}");
            return res.FirstOrDefault();
        }
        public async Task<RoomTemplate> GetByName(string name)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RoomTemplate>(TableName,$"RoomName='{name}'");
            return res.FirstOrDefault();
        }

        public async Task<string[]> GetNames()
        {
            var res = await _databases.Dorm.SelectDistinctAsync(TableName, "RoomName");
            return res;
        }
        public async Task<bool> AddTemplate(int roomId,string roomName)
        {
            StoredProcedureContrainer storedProcedure = new StoredProcedureContrainer("sp_SaveTemplate");
            storedProcedure.Addparameters("rid", roomId);
            storedProcedure.Addparameters("roomName", roomName);
            var res = await _databases.Dorm.ExecuteStoredProcedureAsync(storedProcedure);
            return res.HasCompleted;
        }
    }
}
