using dormitoryApps.Server.Databases;
using dormitoryApps.Server.Securites;
using dormitoryApps.Shared.Model.Entity;
using System.Linq;
using System.Collections.Generic;
using RocketSQL;
using dormitoryApps.Shared.Model.Other;

namespace dormitoryApps.Server.Repository
{
    public class OfficerRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "officer";

        public OfficerRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<bool> Create(Officer item)
        {           
                var res = await _databases.Dorm.InsertEntitiesAsync<Officer>(item);
                return res;       
        }
        public async Task<bool> Update (Officer item)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id", item.Id);
            var myid = await _databases.Dorm.SelectEntitiesAsync<Officer>(TableName, $"Id={item.Id}");
            item.Password = myid.FirstOrDefault().Password;
            item.Idx = myid.FirstOrDefault().Idx;
            var res = await _databases.Dorm.UpdateEntityAsync<Officer>(item, set);
            return res == 1;
        }
        public async Task<List<Officer>> Getall()
        {
            var officersLists = await _databases.Dorm.SelectEntitiesAsync<Officer>();
            var officersList = officersLists.ToList();
            officersList.ForEach(x => { x.Password = "PASSWORD"; x.Idx = "Index"; });
            return officersList.ToList();
        }
        public async Task<List<Officer>> GetExpired()
        {
            ConditionSet set = new ConditionSet();
            set.Add("Expired", true);
            var officersLists = await _databases.Dorm.SelectEntitiesAsync<Officer>(TableName, set);
            var officersList = officersLists.ToList();
            officersList.ForEach(x => { x.Password = "PASSWORD";x.Idx = "Index"; });
            return officersList.ToList();
        }
        public async Task<List<Officer>> GetNotExpired()
        {
            ConditionSet set = new ConditionSet();
            set.Add("Expired", false);
            var officersLists = await _databases.Dorm.SelectEntitiesAsync<Officer>(TableName, set);
            var officersList = officersLists.ToList();
            officersList.ForEach(x => { x.Password = "PASSWORD"; x.Idx = "Index"; });
            return officersList.ToList();
        }
        public async Task<Officer> GetById(long Id)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id", Id);
            var officer = await _databases.Dorm.SelectEntitiesAsync<Officer>(TableName, set);
            var res = officer.FirstOrDefault();
            res.Password = "PASSWORD";
            res.Idx = "INDEX";
            return res;
        }
        public async Task<Officer> GetByUsername(string Username)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Username", Username,SqlOperator.Equal,SqlCondition.OR);
            set.Add("Email", Username, SqlOperator.Equal);
            var officer = await _databases.Dorm.SelectEntitiesAsync<Officer>(TableName, set);
            var res = officer.FirstOrDefault();
            res.Password = "PASSWORD";
            res.Idx = "INDEX";
            return res;
        }

        // Login
        public async Task<bool> LoginCheck(string username,string password)
        {
            StoredProcedureContrainer callIdx = new StoredProcedureContrainer("sp_callsalt");
            callIdx.Addparameters("name", username);
            var spres = _databases.Dorm.ExecuteStoredProcedure(callIdx);
            if(!spres.HasCompleted || !spres.HasReturn)
            {
                return false;
            }
            PasswordHash hash = new PasswordHash();
            var resTable = spres.ConvertResultToDatatable();
            var salt = resTable.Rows[0][0].ToString();
            var arr = Convert.FromBase64String(salt);
            password = Convert.ToBase64String(hash.CreateHash(password,arr));
            StoredProcedureContrainer callLogin = new StoredProcedureContrainer("sp_login");
            callLogin.Addparameters("uname", username);
            callLogin.Addparameters("pwd", password);
            spres= await _databases.Dorm.ExecuteStoredProcedureAsync(callLogin);
            if (!spres.HasCompleted || !spres.HasReturn)
            {
                return false;
            }
            int cnt = (from Dictionary<string,object> response  in spres.Result
                       select (int)response["count"]
                       ).FirstOrDefault();
            return cnt == 1;
        }
        public async Task<int> PostitionDeleted(int PostitionId)
        {
            DBDataContrainer contrainer = new DBDataContrainer();
            contrainer.ColumnName = "Postition";
            contrainer.Value = null;
            var res = await _databases.Dorm.UpdateAsync(TableName,contrainer, $"Postition={PostitionId}");
            return res;
        }
        public async Task<int> PostitionUpgrade(IEnumerable<NewPostitionParameter> items)
        {
            List<StoredProcedureResult> results = new List<StoredProcedureResult>();
            foreach(var item in items)
            {
                StoredProcedureContrainer storedProcedure = new StoredProcedureContrainer("sp_upgradepostition");
                storedProcedure.Addparameters("empId", item.OfficerId);
                storedProcedure.Addparameters("newpost", item.PositionId);
                storedProcedure.Addparameters("newsalary", item.Salary);
                var result = await _databases.Dorm.ExecuteStoredProcedureAsync(storedProcedure);
                results.Add(result);               
            }
            return results.Where(x=>x.HasCompleted).Count();
        }
        public async Task<bool> GetExistUsername(string username)
        {
            var office = await Getall();
            var usernamelist = office.Select(x => x.Username);
            var res = usernamelist.Where(x => x == username);
            return res.Count() <= 0;
        }
        public async Task<bool> GetExistEmail(string Email)
        {
            var office = await Getall();
            var emaillist = office.Select(x => x.Email);
            var res = emaillist.Where(x => x == Email);
            return res.Count() <=0  ;
        }

    }

}
