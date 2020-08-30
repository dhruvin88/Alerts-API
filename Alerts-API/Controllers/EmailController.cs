using Email_API.DTOs;
using Email_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Email_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /// <summary>
        /// Send Email to a Email Address.
        /// </summary>
        [HttpPost]
        [Authorize]
        public IActionResult SendEmail([FromBody] EmailRequestDto email)
        {
            _emailService.SendEmail(email);
            return Accepted();
        }
    }
}
