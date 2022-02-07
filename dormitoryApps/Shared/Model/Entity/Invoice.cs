using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class Invoice
    {
		public string Id { get; set; }
		public string RentalId { get; set; }
		public decimal GrandTotal { get; set; }
		public decimal Fee { get; set; }
		public decimal Paid { get; set; }
		public decimal Changes { get; set; }
		public DateTime InvoiceDate { get; set; }
		public DateTime? PaidDate { get; set; }
		public string Paidwith { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }
		public long InvoiceOfficer { get; set; }
		public long? PaidOfficer { get; set; }
		public string? TransactionId { get; set; }
		public decimal? Discount { get; set; }
		public bool IsService { get; set; }
		public int Service { get; set; }
		public bool Iscancel { get; set; } = false;
		public bool Ispaid { get; set; }
		public decimal ServicePrice { get; set; }
		public virtual Electricity Electricity { get; set; }
		public virtual Water Water { get; set; }
		public virtual List<InvoiceService> Services { get; set; }
	}
}
