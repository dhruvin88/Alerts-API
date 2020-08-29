using Email_API.DTOs;

namespace Email_API.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailRequestDto email);
    }
}