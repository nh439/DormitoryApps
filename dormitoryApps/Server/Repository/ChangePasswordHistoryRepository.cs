using dormitoryApps.Server.Databases;

namespace dormitoryApps.Server.Repository
{
    public class ChangePasswordHistoryRepository
    {
        private readonly DBConnection _databases;
        private const string TableName = "changepasswordhistory";
        public ChangePasswordHistoryRepository(DBConnection databases)
        {
            _databases = databases;
        }

    }
}
