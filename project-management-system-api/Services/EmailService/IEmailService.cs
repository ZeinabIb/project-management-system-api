using project_management_system_api.Email;

namespace project_management_system_api.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
        void SendMeetingEmail(EmailDto request);
    }
}
