using RocketSQL;
using RocketSQL.MySql;
namespace dormitoryApps.Server.Databases
{
    public class Databases
    {
        public Mysql mysql = new Mysql();
        public Databases(IConfiguration configuration)
        {
            mysql.ConnectionString = configuration.GetConnectionString("Def");
        }
    }
}
