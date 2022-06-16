using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace ReversiMvcApp.Helper
{
    public class EmailHelper : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.Factory.StartNew(() =>
            {
                var smtpClient = new SmtpClient("127.0.0.1")
                {
                    Port = 25,
                    Credentials = new NetworkCredential("root", "root"),

                };

                smtpClient.Send("root@localhost", "root@localhost", subject, htmlMessage);

            });
        }
    }
}
