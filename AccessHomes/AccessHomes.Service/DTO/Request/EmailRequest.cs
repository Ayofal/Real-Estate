using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Request
{
    public class EmailRequest
    {
        public string From { get; set; } = "noreply@accessbankplc.com";
        public string Recipient { get; set; }
        public string CopyAddress { get; set; } = null;
        public string Subject { get; set; }
        public string Content { get; set; }
        public string DisplayName { get; set; } = "Access Bank";
    }
}
