using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class CurrentCustomer
    {
		public string Id { get; set; }
		public int RoomId { get; set; }
		public string Firstname { get; set; }
		public string Surname { get; set; }
		public DateTime Stayed { get; set; }
		public byte IsMain { get; set; }
		public string Address { get; set; }
		public decimal Rental { get; set; }
		public DateTime ContractDate { get; set; }
		public List<CustomerImg> Imgs { get; set; } 
	}
}
