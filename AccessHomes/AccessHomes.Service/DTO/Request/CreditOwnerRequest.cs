using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Request
{
    public class CreditOwnerRequest
    {
        public decimal Amount { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public int UserID { get; set; }
    }
}
