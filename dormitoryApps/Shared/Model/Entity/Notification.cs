using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class Notification
    {
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public string Header { get; set; }
		public string Detail { get; set; }
		public DateTime Date { get; set; }
		public Int64? SenderId { get; set; }
		public string SenderFrom { get; set; }
		public bool SendAll { get; set; }
		public bool Secure { get; set; } = false;
		public virtual List<NotificationAttendee> Attendees { get; set; }
		public virtual List<NotificationAttachment>? Attachments { get; set; }
	}
}
