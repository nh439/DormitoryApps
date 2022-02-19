using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class RoomFurnHeader
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public bool CustomValue { get; set; }
        public RoomFurnHeaderValues? values { get; set; }
    }
    public static class RoomFurnHeaderAttr
    {
        public const string Attr01 = "Attr01";
        public const string Attr02 = "Attr02";
        public const string Attr03 = "Attr03";
        public const string Attr04 = "Attr04";
        public const string Attr05 = "Attr05";
        public const string Attr06 = "Attr06";
    }
}
