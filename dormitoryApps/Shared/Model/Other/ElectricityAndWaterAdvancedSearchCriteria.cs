using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Other
{
    public class ElectricityAndWaterAdvancedSearchCriteria
    {
        public int? MinMonth { get { return MinMonth; } set { 
            if(MinMonth >12)
                        {
                    MinMonth = 12;
                }
            } }
        public int? MinYear { get; set; }
        public int? MaxMonth
        {
            get { return MaxMonth; }
            set
            {
                if (MaxMonth > 12)
                {
                    MaxMonth = 12;
                }
            }
        }
        public int? MaxYear { get; set; }
        public int? RoomId { get; set; }
        public int? Usage { get; set; }
        public int? UnitPrice { get; set; }
        public bool? Haspaid { get; set; }
        public DateTime? NotedateMin { get { return NotedateMin; } set { NotedateMin = NotedateMin.Date; } }
        public DateTime? NotedateMax { get { return NotedateMax; } set { NotedateMax = NotedateMax.Date; } }
    }
    public static class Usage
    {
        public const int AllUsage = 0;
        public const int Tiny = 1; //0-100
        public const int Minimal = 2; //101-200;
        public const int Normal = 3; // 201-500;
        public const int Massive = 4;// 501+
    }
}
