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
		public DateTime Stayed { get; set; }
		public string Address { get; set; }
		public decimal Rental { get; set; }
		public DateTime? StayUntil { get; set; } //วันที่ออกจากหอ หรือ วันที่ใบจองหมดอายุ(ในกรณีอยู่ในการจอง)
		public DateTime ContractDate { get; set; }
		public bool Booking { get; set; } //อยู่ในการจองห้อง
		public decimal BookingFee { get; set; } //ค่าจอง
		public decimal ContractFee { get; set; } //ค่าทำสัญญาเช่า
		public decimal DamageInsurance { get; set; } //ค่าประกันของเสียหาย
		public string RentalType { get; set; } // ประเภทการเช่า
		public virtual List<RentalMember> Members { get; set; }
		public virtual List<CustomerImg> Imgs { get; set; } 
	}
}
