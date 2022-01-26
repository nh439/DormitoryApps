using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
	public class CustomerImg
	{
		public long Id { get; set; }
		public string RentalId { get; set; }
		public string Filename { get; set; }
		public string Filetype { get; set; }
		public DateTime Date { get; set; }
		public byte[] Img { get; set; }
	}
}
