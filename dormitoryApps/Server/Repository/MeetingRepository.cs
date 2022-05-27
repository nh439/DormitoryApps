﻿using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class MeetingRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "meeting";

        public MeetingRepository(DBConnection databases)
        {
            _databases = databases;
        }

        public async Task<bool> Create(Meeting item)
        {
            var res = await _databases.Dorm.InsertEntitiesAsync<Meeting>(item);
            return res;
        }
        public async Task<bool> Update(Meeting item)
        {
            var res = await _databases.Dorm.UpdateEntityAsync<Meeting>(item, $"Id={item.Id}");
            return res == 1;
        }
        public async Task<bool> Delete(long meetingId)
        {
            StoredProcedureContrainer storedProcedure = new StoredProcedureContrainer("sp_deletemeeting");
            storedProcedure.Addparameters("$meetingId", meetingId);
            var res = await _databases.Dorm.ExecuteStoredProcedureAsync(storedProcedure);
            return res.HasCompleted;
        }
        public async Task<List<Meeting>> GetRelated(long[] idSet)
        {
            ConditionSet set = new ConditionSet();
            if (idSet != null || idSet.Length == 0) return new List<Meeting>();
            object[] idEnumerable = new object[idSet.Length];
            foreach(var id in idSet.Select((x, y) => new { MeetingId=x,Index=y}))
            {
                idEnumerable[id.Index] = id.MeetingId; 
            }
            set.AddIn("Id", idEnumerable);
            var res= await _databases.Dorm.SelectEntitiesAsync<Meeting>(TableName, set);
            return res.ToList();
        }
        public async Task<Meeting> Get(long id)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Meeting>(TableName, $"Id={id}");
            return res.FirstOrDefault();
        }
    }
}
