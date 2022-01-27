using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.location;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class DistrictsRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "districts";

        public DistrictsRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<List<Districts>> Getall()
        {
            var res = await _databases.Location.SelectEntitiesAsync<Districts>();
            return res.ToList();
        }
        public async Task<List<Districts>> GetByProvince(string province)
        {
            var res = await _databases.Location.SelectEntitiesAsync<Districts>(TableName,$"province='{province}'");
            return res.ToList();
        }
        public async Task< IEnumerable<string>> GetProvince()
        {
            var res = await _databases.Location.SelectDistinctAsync(TableName, "province");
            return res;
        }
        public async Task<IEnumerable<string>> Getdistricts(string province)
        {
            ConditionSet set = new ConditionSet();
            set.Add("province", province, SqlOperator.Equal);
            var res = await _databases.Location.SelectEntitiesAsync<Districts>(TableName, set);
            return res.Select(x => x.amphoe).Distinct();
        }
        public async Task<IEnumerable<string>> GetSubdistricts(string province,string district)
        {
            ConditionSet set = new ConditionSet();
            set.Add("province", province, SqlOperator.Equal,SqlCondition.AND);
            set.Add("amphoe", district, SqlOperator.Equal);
            var res = await _databases.Location.SelectEntitiesAsync<Districts>(TableName, set);
            res = res.Distinct();
            return res.Select(x => x.district);
        }
        public async Task<int> GetPostalCode(string province, string district,string Subdistrict)
        {
            ConditionSet set = new ConditionSet();
            set.Add("province", province, SqlOperator.Equal, SqlCondition.AND);
            set.Add("amphoe", district, SqlOperator.Equal,SqlCondition.AND);
            set.Add("district", Subdistrict);
            var res = await _databases.Location.SelectEntitiesAsync<Districts>(TableName, set);            
            return res.Select(x => int.Parse(x.zipcode)).FirstOrDefault();
        }

    }
}
