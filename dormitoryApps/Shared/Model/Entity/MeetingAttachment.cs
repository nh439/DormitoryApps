using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class MeetingAttachment
    {
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public Int64 MeetingId { get; set; }
		public string FileName { get; set; }
		public string FileExtension { get; set; }
		public string FileType { get; set; }
		public Int64 FileSize { get; set; }
		public byte[] FileContent { get; set; }
	}
}
