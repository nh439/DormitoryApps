using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class RentalMember
    {
        public string RentalId { get; set; }
        public long MemberId { get; set; }
        public bool IsMain { get; set; }
        public virtual CurrentCustomer? CurrentCustomer { get; set; }
        public virtual PastCustomer? PastCustomer { get; set; }
        public virtual Member Member { get; set; }
    }
}
