using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class Room
    {
		public int Id { get; set; }
		public string RoomName { get; set; }
		public int Floor { get; set; }
		public decimal Size { get; set; }
		public int Building { get; set; }
		public bool Aircond { get; set; }
		public bool WaterHeater { get; set; }
		public bool TV { get; set; }
		public bool Fan { get; set; }
		public decimal Rental { get; set; }
		public bool Furniture { get; set; }
		public bool Fridge { get; set; }
		public virtual List<RoomImg> Imgs { get; set; }
		public virtual List<RoomFurn> FurnitureList { get; set; }
		
	}
}
