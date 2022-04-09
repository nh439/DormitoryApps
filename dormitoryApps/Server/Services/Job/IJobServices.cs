using dormitoryApps.Server.Databases;
using dormitoryApps.Shared.Model.Entity;
using RocketSQL;

namespace dormitoryApps.Server.Services.Job
{
    public interface IJobServices
    {
        void Run();
    }
    public class JobServices : IJobServices
    {
        private readonly DBConnection _databases;
        private const string CurrentCustomerTable = "currentcustomer";
        private const string PastCustomerTable = "pastcustomer";
        public JobServices(DBConnection databases)
        {
            _databases = databases;
        }
        public void Run()
        {
            ExpiredBooking();
            Console.WriteLine($"Job at {DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss")}");
        }
        void ExpiredBooking()
        {
            string customerCondition = "Booking=1 and timestampdiff(day,Stayed,current_timestamp()) >2";
            var customers = _databases.Dorm.SelectEntities<CurrentCustomer>(CurrentCustomerTable,customerCondition).ToList();
            List<PastCustomer> pastCustomers = new List<PastCustomer>();
            foreach (var customer in customers)
            {
                PastCustomer pastCustomer = new PastCustomer()
                {
                    Address = customer.Address,
                    ContractDate = customer.ContractDate,
                    DamageFee = 0,
                    Deposit = 0,
                    EmployeeId = customer.EmployeeId,
                    Id = customer.Id,
                    IsStayed = false,
                    Members = customer.Members,
                    Refunded = false,
                    Rental = customer.Rental,
                    RentalType = customer.RentalType,
                    RoomId = customer.RoomId,
                    Stayed = customer.Stayed,
                    StayUntil = DateTime.Now
                };
                pastCustomers.Add(pastCustomer);
            }
            _databases.Dorm.InsertEntities<PastCustomer>(pastCustomers);
            _databases.Dorm.Delete(CurrentCustomerTable, customerCondition);
        }
    }
}
