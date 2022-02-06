using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class InvoiceService
    {
        public string InvoiceId { get; set; }
        public long ServiceId { get; set; }
        public decimal Price { get; set; }
    }
}
