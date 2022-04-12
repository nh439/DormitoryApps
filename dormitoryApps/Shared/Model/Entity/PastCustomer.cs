using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class PastCustomer
    {
		public string Id { get; set; }
		public int RoomId { get; set; }
		public DateTime? Stayed { get; set; }
		public string Address { get; set; }
		public decimal Rental { get; set; }
		public DateTime ContractDate { get; set; }
		public DateTime StayUntil { get; set; }
		public decimal Deposit { get; set; }
		public decimal DamageFee { get; set; }
		public bool Refunded { get; set; }
		public bool IsStayed { get; set; }
		public string RentalType { get; set; }
		public long EmployeeId { get; set; }
		public RentalAccount? Account { get; set; }
		public virtual List<RentalMember> Members { get; set; }
	}
}
