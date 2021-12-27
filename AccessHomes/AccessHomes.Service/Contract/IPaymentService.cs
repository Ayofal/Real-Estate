using AccessHomes.Service.DTO.Request;
using AccessHomes.Service.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.Contract
{
    public interface IPaymentService
    {
        bool AuthorizeDebit(AuthorizeDebitRequest authorizationRequest);

        DebitCustomerResponse DebitCustomer(DebitCustomerRequest debitRequest);

        CreditOwnerResponse CreditOwner( CreditOwnerRequest debitRequest);
    }
}
