using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Entity
{
    public class Session
    {
        public string Id { get; set; }
        public long UserId { get; set; }
        public DateTime LoggedIn { get; set; }
        public DateTime? LoggOut { get; set; }
        public bool Isloggout { get; set; }
    }
}
