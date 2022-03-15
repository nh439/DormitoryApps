using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class RentalMemberRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "rentalmember";

        public RentalMemberRepository(DBConnection databases)
        {
            _databases = databases;
        }

        public async Task<bool> Create(RentalMember item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RentalMember>(item);
            return res;
        }
        public async Task<int> Create(IEnumerable<RentalMember> items)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<RentalMember>(items);
            return res;
        }
        public async Task<bool> SetnewRentalIsMain(RentalMember isMainitem)
        {
            try
            {
                DBRowContrainer row = new DBRowContrainer();
                row.Add("IsMain", false);
                await _databases.Dorm.UpdateAsync(row, $"RentalId='{isMainitem.RentalId}'");
                isMainitem.IsMain = true;
                var res = await _databases.Dorm.UpdateEntityAsync<RentalMember>(isMainitem, $"RentalId='{isMainitem.RentalId}' and MemberId={isMainitem.MemberId}");
                return true;
            }
            catch(Exception x)
            {
                return false;
            }
        }
        public async Task<List<RentalMember>> GetByRentalId(string rentalId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RentalMember>(TableName,$"RentalId='{rentalId}'");
            return res.ToList();
        }
        public async Task<List<RentalMember>> GetByMember(long memberId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<RentalMember>(TableName, $"MemberId={memberId}");
            return res.ToList();
        }

    }
}
