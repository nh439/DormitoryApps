using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class RoomTemplate
    {
		public int Id { get; set; }
		public string TemplateName { get; set; }
		public decimal? Size { get; set; }
		public bool Aircond { get; set; }
		public bool WaterHeater { get; set; }
		public bool TV { get; set; }
		public bool Fan { get; set; }
		public decimal Rental { get; set; }
		public bool Furniture { get; set; }
		public bool Fridge { get; set; }
		public virtual List<RoomfurnTemplate> Furnitures { get; set; }
	}
}
