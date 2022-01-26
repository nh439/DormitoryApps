﻿using dormitoryApps.Server.Databases;
using dormitoryApps.Server.Securites;
using dormitoryApps.Shared.Model.Entity;
using System.Linq;
using System.Collections.Generic;
using RocketSQL;

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
        public async Task< bool> Create(Officer item)
        {
            var res = await _databases.mysql.InsertEntitiesAsync<Officer>(item);
            return res;
        }
        public async Task<bool> Update (Officer item)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id", item.Id);
            var res = await _databases.mysql.UpdateEntityAsync<Officer>(item, set);
            return res == 1;
        }
        public async Task<List<Officer>> Getall()
        {
            var officersList = await _databases.mysql.SelectEntitiesAsync<Officer>();
            return officersList.ToList();
        }
        public async Task<List<Officer>> GetExpired()
        {
            ConditionSet set = new ConditionSet();
            set.Add("Expired", true);
            var officersList = await _databases.mysql.SelectEntitiesAsync<Officer>(TableName,set);
            return officersList.ToList();
        }
        public async Task<List<Officer>> GetNotExpired()
        {
            ConditionSet set = new ConditionSet();
            set.Add("Expired", false);
            var officersList = await _databases.mysql.SelectEntitiesAsync<Officer>(TableName, set);
            return officersList.ToList();
        }
        public async Task<Officer> GetById(long Id)
        {
            ConditionSet set = new ConditionSet();
            set.Add("Id", Id);
            var officer = await _databases.mysql.SelectEntitiesAsync<Officer>(TableName, set);
            return officer.FirstOrDefault();
        }

        // Login
        public async Task<bool> LoginCheck(string username,string password)
        {
            StoredProcedureContrainer callIdx = new StoredProcedureContrainer("sp_callsalt");
            callIdx.Addparameters("name", username);
            var spres = _databases.mysql.ExecuteStoredProcedure(callIdx);
            if(!spres.HasCompleted || !spres.HasReturn)
            {
                return false;
            }
            PasswordHash hash = new PasswordHash();
            var salt = spres.Result[0]["Idx"].ToString();
            var arr = Convert.FromBase64String(salt);
            password = Convert.ToBase64String(hash.CreateHash(password,arr));
            StoredProcedureContrainer callLogin = new StoredProcedureContrainer("sp_login");
            callLogin.Addparameters("username", username);
            callLogin.Addparameters("password", password);
            spres= await _databases.mysql.ExecuteStoredProcedureAsync(callLogin);
            if (!spres.HasCompleted || !spres.HasReturn)
            {
                return false;
            }
            int cnt = (from Dictionary<string,object> response  in spres.Result
                       select (int)response["count"]
                       ).FirstOrDefault();
            return cnt == 1;
        }
    }

}
