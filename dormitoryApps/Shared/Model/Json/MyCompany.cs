using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Json
{
    public class MyCompany
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEN { get; set; }
        public string NameSET { get; set; }
        public string Description { get; set; }
        public int TaxIdentification { get; set; }
        public string Type { get; set; }//บริษัท ห้างหุ้นส่วน
        public decimal RegisteredCapital { get; set; }
        public int? RegisteredYear { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public int Tel { get; set; }
        public int Tel2 { get; set; }

    }
}
