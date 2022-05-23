using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class NotificationAttendee
    {
        public string NotificationId { get; set; }
        public Int64 UserId { get; set; }
        public string? Remark { get; set; }
    }
}
