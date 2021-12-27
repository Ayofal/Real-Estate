using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Request
{
    public class AuthorizeDebitRequest
    {
        public string AccountNumber { get; set; }

        public string BankCode  { get; set; }

        public string BankName { get; set; }

        public string AuthorizationToken { get; set; }

        public Frequency Frequency  { get; set; }

    }

    public enum Frequency
    {
        Daily,
        Weekly,
        Monthly,
        Quaterly,
        BiMonthly,
        Annually
   
    }
}
