using System.Threading.Tasks;

namespace XCore.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
        Task SendMessageAsync(EmailDto emailDto);
    }
}
