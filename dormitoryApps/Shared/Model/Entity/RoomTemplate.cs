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
		public string RoomName { get; set; }
		public decimal? Size { get; set; }
		public byte Aircond { get; set; }
		public byte WaterHeater { get; set; }
		public byte TV { get; set; }
		public byte Fan { get; set; }
		public decimal Rental { get; set; }
		public byte Furniture { get; set; }
		public byte Fridge { get; set; }
		public byte Enabled { get; set; }
		public virtual List<RoomfurnTemplate> Furnitures { get; set; }
	}
}
