using AccessHomes.Service.DTO.Request;
using AccessHomes.Service.DTO.Response;
using System.Threading.Tasks;

namespace AccessHomes.Service.Contract
{
    public interface INotificationService
    {
        Task<EmailResponse> SendEmail(EmailRequest dto);
        Task<SMSResponse> SendSMS(SMSRequest dto);
    }
}
