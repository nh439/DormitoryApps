using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class Member
    {
		public long MemberId { get; set; }
		public string Firstname { get; set; }
		public string Surname { get; set; }
		public string Prefix { get; set; }
		public string SocialId { get; set; }
		public string SocialType { get; set; }
		public virtual List<RentalMember>? Rentals { get; set; }
	}
}
