﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class RentalAccount
    {
        public string RentalId { get; set; }
        public string Bank { get; set; }
        public long AccountId { get; set; }
        public string AccountName { get; set; }
        public bool Specify { get; set; }
    }
}
