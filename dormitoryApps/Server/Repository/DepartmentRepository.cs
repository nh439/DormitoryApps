using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;
namespace dormitoryApps.Server.Repository
{
    public class DepartmentRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "department";

        public DepartmentRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Department item)
        {
            var res = await _databases.mysql.InsertEntitiesAsync<Department>(item);
            return res;
        }
        public async Task< bool> Update(Department item)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id",item.Id,SqlOperator.Equal);
            var res = await _databases.mysql.UpdateEntityAsync<Department>(item,set);
            return res == 1;
        }
        public async Task<List<Department>> Getall()
        {
            IEnumerable<Department> departments = await _databases.mysql.SelectEntitiesAsync<Department>();
            return departments.ToList();
        }
        public async Task<Department> GetById(int departmantId)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id", departmantId);
            IEnumerable<Department> department = await _databases.mysql.SelectEntitiesAsync<Department>(TableName,set);
            return department.FirstOrDefault();
        }      
    }
}
