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
        public DateBetween? InvoiceDate { get; set; }
        public DateBetween? PaidDate { get; set; }
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
