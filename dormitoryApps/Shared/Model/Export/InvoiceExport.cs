using dormitoryApps.Shared.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Export
{
    public class InvoiceExport
    {
        public string InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public CurrentCustomer Customers { get; set; }
        public PastCustomer PastCustomer { get; set; }
        public Officer InvoiceOfficer { get; set; }
        public Officer PaidOfficer { get; set; }
        public Officer ExportedOfficer { get; set; }
        public DateTime ExportDate { get; set; }= DateTime.Now;


    }
}
