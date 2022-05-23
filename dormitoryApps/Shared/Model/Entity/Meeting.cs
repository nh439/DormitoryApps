using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class Meeting
    {
		public Int64 Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public bool OnLine { get; set; }
		public string? Place { get; set; }
		public string? Link { get; set; }
		public DateTime CreateDate { get; set; }
		public Int64 CreateBy { get; set; }
		public bool IsCompleted { get; set; }
		public string Remark { get; set; }
	}
}

