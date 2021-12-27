using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Response
{
    public class SMSResponse
    {
        public string response_code { get; set; }
        public string response_desc { get; set; }
        public string response_message { get; set; }
        public string applicationId { get; set; }
        public string receiverNumber { get; set; }
    }
}
