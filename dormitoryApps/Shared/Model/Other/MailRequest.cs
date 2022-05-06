using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dormitoryApps.Shared.Model.Other
{
    public class MailRequest
    {
        public string[] ToEmail { get; set; }
        public string[] CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string DisplayName { get; set; }
        public List<EmailAttachment> Attachments { get; set; }
    }
}
