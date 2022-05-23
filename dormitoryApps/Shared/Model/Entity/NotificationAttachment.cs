using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class NotificationAttachment
    {
		public string Id { get; set; }=Guid.NewGuid().ToString();
		public string NotificationId { get; set; }
		public string FileName { get; set; }
		public string FileExtension { get; set; }
		public Int64 FileSize { get; set; }
		public string FileType { get; set; }
		public byte[] FileContent { get; set; }
		public DateTime FileCreateDate { get; set; }
	}
}
