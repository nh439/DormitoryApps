using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class Address
    {
		public string Id { get; set; }
		public string etc { get; set; }
		public int Moo { get; set; }
		public string Subdistrict { get; set; }
		public string District { get; set; }
		public string Province { get; set; }
		public int PostalCode { get; set; }
	}
}
