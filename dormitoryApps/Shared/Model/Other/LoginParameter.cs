using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Other
{
    public class LoginParameter
    {
        public byte[] Content { get; set; }
        public string Reference { get; set; } = Guid.NewGuid().ToString();
        public DateTime TimeStamp = DateTime.Now;
    }
}
