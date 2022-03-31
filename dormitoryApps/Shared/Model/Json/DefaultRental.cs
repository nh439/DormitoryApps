using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Json
{
    public class DefaultRental
    {
        public decimal BookingFee { get; set; }
        public decimal Taxpercentage { get; set; }
        public decimal ContractFee { get; set; }
        public bool Readonly { get; set; }
    }
}
