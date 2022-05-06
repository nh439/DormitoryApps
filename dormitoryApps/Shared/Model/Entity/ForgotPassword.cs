using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class ForgotPassword
    {
		public Int64 Id { get; set; }
		public Int64 UserId { get; set; }
		public DateTime ForgotDate { get; set; } = DateTime.Now;
		public string Email { get; set; }
		public string Token { get; set; } = ObjectGenerate.ObjectRandom.RandomText(50);
		public DateTime ExpiredAt { get; set; } = DateTime.Now.AddMinutes(15);
		public bool HasReset { get; set; }
		public int Password { get; set; } = ObjectGenerate.ObjectRandom.CreatePin(6);
		public bool Expired { get; set; }
		public bool Admin { get; set; }
	}
}
