using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using project_management_system_api.Services.EmailService;

namespace project_management_system_api.Email
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService) {
            _emailService= emailService;
        }

        /*
         Name	Hilda Sawayn
Username	hilda31@ethereal.email
Password	cdtYv22kxN5jv82h4H*/


        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailService.SendEmail(request);
           

            return Ok();
        }


        [HttpPost("send/vacation")]
        public IActionResult SendVacationEmail(EmailDto request)
        {
            request.Subject = "Vacation Notice";
            request.Body = "This is a vacation email. " + request.Body;
            _emailService.SendEmail(request);
            return Ok();
        }

        [HttpPost("send/meeting")]
        public IActionResult SendMeetingEmail(EmailDto request)
        {
            request.Subject = "Meeting Notice";
            request.Body = "There will be a meeting.";
            _emailService.SendMeetingEmail(request);
            return Ok();
        }
    }
}
