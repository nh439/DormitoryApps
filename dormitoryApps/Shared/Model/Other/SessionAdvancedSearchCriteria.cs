﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Other
{
    public class SessionAdvancedSearchCriteria
    {
        public SessionDate LoggedIn { get; set; }
        public SessionDate LoggedOut { get; set; }
        public int? UserId { get; set; }
        public int IsloggedOut { get; set; } = 0;
    }
    public class SessionDate
    {
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
    }
}
