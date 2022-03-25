using dormitoryApps.Server.Databases;

namespace dormitoryApps.Server.Services.Job
{
    public interface IJobServices
    {
        void Run();
    }
    public class JobServices : IJobServices
    {
        private readonly DBConnection _databases;
        public JobServices(DBConnection databases)
        {
            _databases = databases;
        }
        public void Run()
        {
            Console.WriteLine($"Job at {DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss")}");
        }
    }
}
