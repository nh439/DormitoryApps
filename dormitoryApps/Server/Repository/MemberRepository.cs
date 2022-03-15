using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class MemberRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "member";
        public MemberRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Member item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Member>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable<Member> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Member>(items);
            return res;
        }
        public async Task<bool> Update(Member item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<Member>(item,$"MemberId={item.MemberId}");
            return res==1;
        }
        public async Task<List<Member>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Member>();
            return res.ToList();
        }
        public async Task<List<Member>> GetIn(IEnumerable<long> itemIdCollection)
        {
            ConditionSet set = new ConditionSet();
            List<object> list = new List<object>();
            foreach(var item in itemIdCollection)
            {
                list.Add(item);
            }
            set.AddIn("MemberId", list);
            var res = await _databases.Dorm.SelectEntitiesAsync<Member>();
            return res.ToList();
        }
        public async Task<Member>GetById(long id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Member>(TableName, $"MemberId={id}");
            return res.FirstOrDefault();
        }
        public long Autoincrement()
        {
            var res = _databases.Dorm.GenerateId(TableName, "MemberId");
            return res;
        }
        public IEnumerable<long> Autoincrement(int rows)
        {
            var res = _databases.Dorm.GenerateId(TableName, "MemberId");
            List<long> IdSet = new List<long>();
            for(int i=0;i<rows;i++)
            {
                IdSet.Add(res + i);
            }
            return IdSet;
        }

    }
}
