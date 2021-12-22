using MimeKit;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace XCore.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(Message message)
        {
            Send(CreateEmailMessage(message));
        }

        public async Task SendEmailAsync(Message message)
        {
            await SendAsync(CreateEmailMessage(message));
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_emailConfig.From));
            mimeMessage.To.AddRange(message.To);
            mimeMessage.Subject = message.Subject;

            BodyBuilder bodyBuilder = new BodyBuilder()
            {
                HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content)
            };
            if (message.Attachments != null && message.Attachments.Any())
            {
                foreach (IFormFile attachment in (IEnumerable<IFormFile>)message.Attachments)
                {  
                    byte[] array;
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        attachment.CopyTo((Stream)memoryStream);
                        array = memoryStream.ToArray();
                    }
                    bodyBuilder.Attachments.Add(attachment.FileName, array, ContentType.Parse(attachment.ContentType));
                }
            }
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            return mimeMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                try
                {
                    smtpClient.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                    smtpClient.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    smtpClient.Send(mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    smtpClient.Disconnect(true);
                    smtpClient.Dispose();
                }
            }
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using (SmtpClient client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        public async Task SendMessageAsync(EmailDto emailDto)
        {
            MimeMessage message = new MimeMessage();
            message.Sender = MailboxAddress.Parse(_emailConfig.From);
            message.To.Add(new MailboxAddress("X-Core", "xcore.web.development@gmail.com"));
            message.Subject = emailDto.Subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            message.Body = bodyBuilder.ToMessageBody();
            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
                await smtp.SendAsync(message);
                smtp.Disconnect(true);
            }
        }
    }
}
