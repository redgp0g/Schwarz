using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace Schwarz.Services.Interfaces
{
    public interface IEmailService
    {

        public void SendEmail(string subject, string message,string email);

    }
}
