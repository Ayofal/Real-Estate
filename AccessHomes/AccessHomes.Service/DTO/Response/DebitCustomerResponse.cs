using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Response
{
    public class DebitCustomerResponse
    {
        public string Reference { get; set; }
        public TransactionStatus Status { get; set; }
        public decimal Amount { get; set; }
        public string BankCode { get; set; }
        public int UserID { get; set; }
    }


    public enum TransactionStatus
    {
            Successful, 
            Failed, 
            Pending,
            Reversed
    }
}
