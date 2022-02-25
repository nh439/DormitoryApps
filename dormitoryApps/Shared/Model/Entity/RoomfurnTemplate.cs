using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class RoomfurnTemplate
    {
		public long Id { get; set; }
		public int RoomId { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public decimal Price { get; set; }
		public string Model { get; set; }
		public string Attr01 { get; set; }
		public string Attr02 { get; set; }
		public string Attr03 { get; set; }
		public string Attr04 { get; set; }
		public string Attr05 { get; set; }
		public string Attr06 { get; set; }
	}
}
