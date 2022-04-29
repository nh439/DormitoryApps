using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using dormitoryApps.Shared.Model.Other;
using RocketSQL;

namespace dormitoryApps.Server.Repository
{
    public class SessionRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "Session";
        public SessionRepository(DBConnection databases)
        {
            _databases = databases;
        }
        public async Task<string> Createlogin(long userId)
        {
            StoredProcedureContrainer contrainer = new StoredProcedureContrainer("sp_createSession");
            contrainer.Addparameters("Id", userId);
            var res = await _databases.Dorm.ExecuteStoredProcedureAsync(contrainer);
            if(!res.HasCompleted)
            {
                throw new Exception(res.Exception.Message);
            }
            string sessionId = res.Result[0]["SessionId"].ToString();
            return sessionId;
        }
        public async Task<bool> SetLogout(string SessionId)
        {
            StoredProcedureContrainer contrainer = new StoredProcedureContrainer("sp_setLogout");
            contrainer.Addparameters("Sid", SessionId);
            var res = await _databases.Dorm.ExecuteStoredProcedureAsync(contrainer);
            return res.HasCompleted;
        }
        public async Task<bool> ForceLogout(long UserId)
        {
            StoredProcedureContrainer contrainer = new StoredProcedureContrainer("sp_ForcedLogout");
            contrainer.Addparameters("Id", UserId);
            var res = await _databases.Dorm.ExecuteStoredProcedureAsync(contrainer);
            return res.HasCompleted;
        }
        public async Task<List<Session>> Getall()
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Session>();
            return res.ToList();
        }
        public async Task<List<Session>> GetByUser(long UserId)
        {
            var res = await _databases.Dorm.SelectEntitiesAsync<Session>(TableName,$"UserId={UserId}");
            return res.ToList();
        }
        public async Task<List<Session>> GetWithAdvanceSearch(SessionAdvancedSearchCriteria criteria)
        {
            ConditionSet set = new ConditionSet();
            if (criteria.LoggedIn != null)
            {
                if (criteria.LoggedIn.MinDate.HasValue)
                {
                    set.Add("LoggedIn", criteria.LoggedIn.MinDate.Value.Date, SqlOperator.MoreThanOrEqual, SqlCondition.AND);
                }
                if (criteria.LoggedIn.MaxDate.HasValue)
                {
                    set.Add("LoggedIn", criteria.LoggedIn.MaxDate.Value.Date.AddDays(1), SqlOperator.LessThanOrEqual, SqlCondition.AND);
                }
            }
            if (criteria.LoggedOut != null)
            {
                if (criteria.LoggedOut.MinDate.HasValue)
                {
                    set.Add("LoggOut", criteria.LoggedOut.MinDate.Value.Date, SqlOperator.MoreThanOrEqual, SqlCondition.AND);
                }
                if (criteria.LoggedOut.MaxDate.HasValue)
                {
                    set.Add("LoggOut", criteria.LoggedOut.MaxDate.Value.Date.AddDays(1), SqlOperator.LessThanOrEqual, SqlCondition.AND);
                }
            }
            if(criteria.UserId != 0)
            {
                set.Add("UserId", criteria.UserId, SqlOperator.Equal, SqlCondition.AND);
            }
            if(criteria.IsloggedOut > 0 )
            {
                set.Add("Isloggout", criteria.IsloggedOut == 1 ? true : false);
            }
            var res = await _databases.Dorm.SelectEntitiesAsync<Session>(TableName, set);
            return res.ToList();

        }
        public int SuperForcedlogout(int day)
        {
            DBRowContrainer contrainer = new DBRowContrainer(TableName);
            contrainer.Add("LoggOut", DateTime.Now);
            contrainer.Add("Isloggout",true);
            var res = _databases.Dorm.Update(contrainer, $"TIMESTAMPDIFF(day,LoggedIn,current_timestamp())>{day} and LoggOut is null");
            return res;
        }
        public int DeleteAfterMonth(int month)
        {
            var res = _databases.Dorm.Delete(TableName, $"TIMESTAMPDIFF(month,LoggOut,current_timestamp())>={month}");
            return res;
        }
        public async Task<Officer?> GetCurrentlogin(string SessionId)
        {
            StoredProcedureContrainer contrainer = new StoredProcedureContrainer("sp_getcurrentuser");
            contrainer.Addparameters("sessionId", SessionId);
            var x = await _databases.Dorm.ExecuteStoredProcedureasEntityAsync<Officer>(contrainer);
            Officer? officer = x.FirstOrDefault();
            return officer;
        }
    }
}
