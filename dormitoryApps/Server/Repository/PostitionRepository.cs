using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class PostitionRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "Postition";

        public PostitionRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Postition item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Postition>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable<Postition> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Postition>(items);
            return res;
        }
        public async Task<bool> Update(Postition item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<Postition>(item);
            return res;
        }
        public async Task<bool> Deleted(int Id)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"id={Id}");
            return res == 1;
        }
        public async Task<List<Postition>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Postition>();
            return res.ToList();
        }
        public async Task<List<Postition>> GetByPostitionLine(int lineId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Postition>(TableName, $"Line={lineId}");
            return res.OrderBy(x=>x.Level).ToList();
        } 
        public async Task<List<Postition>> GetByDepartment(int DepartmentId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Postition>(TableName, $"Department={DepartmentId}");
            return res.ToList();
        }
        public async Task<Postition> GetById(int Id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Postition>(TableName,$"Id={Id}");
            return res.FirstOrDefault();
        }
    }
}
