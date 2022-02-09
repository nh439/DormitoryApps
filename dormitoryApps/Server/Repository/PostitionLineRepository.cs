using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class PostitionLineRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "postitionline";

        public PostitionLineRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(PostitionLine item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<PostitionLine>(item);
            return res;
        }
        public async Task<bool> Update(PostitionLine item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<PostitionLine>(item,$"Id={item.Id}");
            return res==1;
        }
        public async Task<bool> Delete(int Id)
        {
            var res = await _databases.Dorm.DeleteAsync(TableName, $"Id={Id}");
            return res == 1;
        }
        public async Task<List<PostitionLine>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<PostitionLine>();
            return res.OrderBy(x=>x.Id).ToList();
        }
        public async Task<PostitionLine> GetById(int id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<PostitionLine>(TableName, $"Id={id}");
            return res.FirstOrDefault();
        }
    }
}
