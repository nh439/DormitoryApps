using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class MeetingAttendee
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Int64 MeetingId { get; set; }
        public Int64 OfficerId { get; set; }
    }
}
