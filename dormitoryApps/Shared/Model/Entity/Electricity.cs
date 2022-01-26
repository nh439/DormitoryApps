using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class Electricity
    {
		public string RentalId { get; set; }
		public int month { get; set; }
		public int Year { get; set; }
		public decimal BeforeUnit { get; set; }
		public decimal CurrentUnit { get; set; }
		public decimal Price { get; set; }
		public decimal Total { get; set; }
		public DateTime Notedate { get; set; }
		public bool Paid { get; set; }		
    }
}
