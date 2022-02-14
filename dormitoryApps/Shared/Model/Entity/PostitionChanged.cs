using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class PostitionChanged
    {
		public long id { get; set; }
		public long officerId { get; set; }
		public int OldPostition { get; set; }
		public decimal OldSalary { get; set; }
		public int NewPostition { get; set; }
		public decimal NewSalary { get; set; }
		public string Remark { get; set; }
		public DateTime Date {get;set;}
}
}
