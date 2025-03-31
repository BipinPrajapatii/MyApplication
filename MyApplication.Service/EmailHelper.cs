using System;
using System.Net;
using System.Net.Mail;
using MyApplication.Core.Model.Email;
using MyApplication.Core.Model.Email.EmailConfiguration;

namespace MyApplication.Service
{
    public interface IEmailSender
    {
        bool SendEmail(EmailModel emailModel);
    }

    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public bool SendEmail(EmailModel emailModel)
        {
            try
            {
                SmtpClient client = new SmtpClient(_emailConfig.SmtpServer)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_emailConfig.From, _emailConfig.Password),
                    Port = _emailConfig.Port,
                    //EnableSsl = _emailConfig.SslRequired,
                    EnableSsl = false,
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailConfig.From, _emailConfig.DisplayName)
                };
                mailMessage.To.Add(emailModel.To);
                mailMessage.Body = emailModel.Message;
                mailMessage.Subject = emailModel.Subject;
                mailMessage.IsBodyHtml = true;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
