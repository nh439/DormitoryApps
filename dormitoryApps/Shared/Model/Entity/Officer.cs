using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
	public class Officer
	{
		public long Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Idx { get; set; }
		public string Email { get; set; }
		public string Prefix { get; set; }
		public string Firstname { get; set; }
		public string Surname { get; set; }
		public DateTime Brithday { get; set; }
		public string Address { get; set; }=Guid.NewGuid().ToString();
		public bool? Gender { get; set; }
		public int Postition { get; set; }
		public decimal Salary { get; set; }
		public DateTime Registerd { get; set; }
		public bool Expired { get; set; } = false;
		public byte[] Img { get; set; }
		public bool Issuper { get; set; }
	}
}
