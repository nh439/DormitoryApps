using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class ChangePasswordHistory
    {
        public Int64 id { get; set; }
        public Int64 UserId { get; set; }
        public DateTime ChangeAt { get; set; }
        public bool IsForgot { get; set; }
        public bool SystemReset { get; set; }
    }
}
