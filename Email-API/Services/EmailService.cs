using Email_API.DTOs;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Email_API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailRequestDto email)
        {
            var fromAddress = new MailAddress(_configuration["FromEmailAddress"], "Alerts");
            var toAddress = new MailAddress(email.EmailAddress);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, _configuration["EmailPassword"])
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = email.Subject ?? string.Empty,
                Body = email.Body ?? string.Empty
            })
            {
                smtp.Send(message);
            }
        }
    }
}
