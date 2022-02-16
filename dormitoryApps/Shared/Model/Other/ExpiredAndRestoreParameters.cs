using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Other
{
    public class ExpiredAndRestoreParameters
    {
        public byte[] Id { get; set; }
        public byte[] Comment { get; set; }
        public bool HasReset { get; set; }
    }
}
