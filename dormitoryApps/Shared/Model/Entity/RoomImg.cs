using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class RoomImg
	{
		public long Id { get; set; }
		public int RoomId { get; set; }
		public string FileName { get; set; }
		public string FileType { get; set; }
		public long Size { get; set; }
		public byte[] Img { get; set; }
	}
}
