using Schwarz.Services.Interfaces;
using System.Net.Mail;
using System.Net;

namespace Schwarz.Services
{
    public class EmailService : IEmailService
    {

        public void SendEmail(string subject, string message, string email)
        {
            MailMessage emailMessage = new();

            var emailComunicacao = Environment.GetEnvironmentVariable("SCHWARZ_EMAIL_COMUNICACAO");
            var senhaEmailComunicacao= Environment.GetEnvironmentVariable("SCHWARZ_SENHA_EMAIL_COMUNICACAO");

            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Timeout = 60000 * 6000,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailComunicacao, senhaEmailComunicacao)
            };
            emailMessage.From = new MailAddress(emailComunicacao, "Schwarz Comunicação");

            emailMessage.Body = message;
            emailMessage.Subject = subject;
            emailMessage.IsBodyHtml = true;
            emailMessage.Priority = MailPriority.Normal;
            emailMessage.To.Add(email);
            smtpClient.Send(emailMessage);
        }
    }
}
