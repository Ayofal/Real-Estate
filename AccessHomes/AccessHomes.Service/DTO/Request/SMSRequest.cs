using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Request
{
    public class SMSRequest
    {
        public string ReceiverNumber { get; set; }
        public string SMSMessage { get; set; }
        public string ApplicationId { get; set; } = "PROCESSMAKER";
        public string Priority { get; set; } = "1";
    }
}
