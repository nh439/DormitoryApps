using RocketSQL;
using RocketSQL.MySql;
using RocketSQL.SQLite;
namespace dormitoryApps.Server.Databases
{
    public class DBConnection
    {
        public Mysql Dorm = new Mysql();
        public Sqlite Location = new Sqlite();
        public DBConnection(IConfiguration configuration)
        {
            Dorm.ConnectionString = configuration.GetConnectionString("Def");
            Location.ConnectionString = configuration.GetConnectionString("loc");
        }
    }
}
