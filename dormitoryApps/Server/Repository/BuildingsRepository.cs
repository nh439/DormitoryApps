using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class BuildingsRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "buildings";

        public BuildingsRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Buildings item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Buildings>(item);
            return res;
        }
        public async Task<bool> Update(Buildings item)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id",item.Id,SqlOperator.Equal);
            var res = await _databases.Dorm.UpdateEntityAsync<Buildings>(item,set);
            return res == 1;
        }
        public async Task< List<Buildings>> GetAll()
        {
            var buildings = await _databases.Dorm.SelectEntitiesAsync<Buildings>();
            return buildings.ToList();
        }
        public async Task< Buildings> GetById(int id)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id", id, SqlOperator.Equal);
            var building = await _databases.Dorm.SelectEntitiesAsync<Buildings>(TableName,set);
            return building.FirstOrDefault();
        }
    }
}
