using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.location
{
    public class Districts
    {
		public long id { get; set; }
		public string district { get; set; }
		public string amphoe { get; set; }
		public string province { get; set; }
		public string zipcode { get; set; }
		public string district_code { get; set; }
		public string amphoe_code { get; set; }
		public string province_code { get; set; }
	}
}
