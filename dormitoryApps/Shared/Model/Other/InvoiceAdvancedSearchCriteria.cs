using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Other
{
    public class InvoiceAdvancedSearchCriteria
    {
        public string? RentalId { get; set; }
        public DateTime? InvoiceDateMin { get; set; }
        public DateTime? InvoiceDateMax { get; set; }
        public DateTime? PaidDateMin { get; set; }
        public DateTime? PaidDateMax { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public long? InvoiceOfficer { get; set; }
        public long? PaidOfficer { get; set; }
        public string? PaidWith { get; set; }

    }
    public class DateBetween
    {
        public DateTime? Min { get; set; }
        public DateTime? Max { get; set; }
    }
}
