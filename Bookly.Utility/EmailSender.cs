using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookly.Utility
{
    public class EmailSender : IEmailSender
    {
        // Send email using SendGrid - only works for domain email addresses, not Gmail, Yahoo, etc.
        // public string SendGridSecret { get; set; }

        //public EmailSender(IConfiguration _config)
        //{
        //    SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");

        //}
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("booklybooksweb@gmail.com"));
            emailToSend.To.Add(MailboxAddress.Parse(email));
            emailToSend.Subject = subject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html){ Text = htmlMessage };

            //send email
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("booklybooksweb@gmail.com", "Xonyx601!");
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
            }

            return Task.CompletedTask;


            // Send email using SendGrid - only works for domain email addresses, not Gmail, Yahoo, etc.

            //var client = new SendGridClient(SendGridSecret);
            //var from = new EmailAddress("hello@mydomainname.com", "BooklyBooks.com");
            //var to = new EmailAddress(email);
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);
            //return client.SendEmailAsync(msg);
        }
    }
}
