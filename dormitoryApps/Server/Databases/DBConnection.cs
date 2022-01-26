using RocketSQL;
using RocketSQL.MySql;
namespace dormitoryApps.Server.Databases
{
    public class DBConnection
    {
        public Mysql mysql = new Mysql();
        public DBConnection(IConfiguration configuration)
        {
            mysql.ConnectionString = configuration.GetConnectionString("Def");
        }
    }
}
