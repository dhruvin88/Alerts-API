using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Email_API.DTOs
{
    public class EmailRequestDto
    {
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

        public EmailRequestDto(){}

        public EmailRequestDto(string emailAddress, string body, string subject)
        {
            EmailAddress = emailAddress;
            Body = body;
            Subject = subject;
        }
    }
}
