using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;

namespace dormitoryApps.Server.Repository
{
    public class PostitionChangedRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "postitionchanged";

        public PostitionChangedRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(PostitionChanged item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<PostitionChanged>(item);
            return res;
        }
        public async Task<List<PostitionChanged>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<PostitionChanged>();
            return res.ToList();
        }
        public async Task<List<PostitionChanged>> GetByofficer(long officerId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<PostitionChanged>(TableName, $"officerId={officerId}");
            return res.ToList();
        }

    }
}
