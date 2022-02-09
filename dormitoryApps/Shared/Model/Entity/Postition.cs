using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
	public class Postition
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Level { get; set; }
		public decimal Salary { get; set; }
		public int Department { get; set; }
		public int Line { get; set; }
		public int? Next { get; set; }
	}
}
