using AccessHomes.Service.Contract;
using AccessHomes.Service.DTO.Request;
using AccessHomes.Service.DTO.Response;
using AccessHomes.Service.Exceptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        internal string _mailURL => _config["APISettings:MailBaseURL"];
        internal string _smsURL => _config["APISettings:SMSBaseURL"];
        internal string _authKey => _config["APISettings:AuthKey"];
        public NotificationService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<EmailResponse> SendEmail(EmailRequest dto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await _httpClient.PostAsync(_mailURL, content);

            string jsonString = await httpResponse.Content.ReadAsStringAsync();
            EmailResponse data = JsonConvert.DeserializeObject<EmailResponse>(jsonString);

            return data;
        }

        public async Task<SMSResponse> SendSMS(SMSRequest dto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            //Add headers
            content.Headers.Add("Authorization", _authKey);
            HttpResponseMessage httpResponse = await _httpClient.PostAsync(_smsURL, content);

            string jsonString = await httpResponse.Content.ReadAsStringAsync();
            SMSResponse data = JsonConvert.DeserializeObject<SMSResponse>(jsonString);

            return data;
        }
    }
}
