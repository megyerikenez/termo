using AutoMapper.Internal;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using Termo.Core.Models.Email;

namespace Termo.Services
{
    public class EmailSender : IEmailSender
    {
        private string smtpServer;
        private int smptPort;
        private string fromEmailAddress;

        public EmailSender(string smtpServer, int smptPort, string fromEmailAddress)
        {
            this.smtpServer = smtpServer;
            this.smptPort = smptPort;
            this.fromEmailAddress = fromEmailAddress;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage
            {
                From = new MailAddress(fromEmailAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(email));

            using (var client = new SmtpClient(smtpServer, smptPort))
            {
                await client.SendMailAsync(message);
            }
        }
    }
}
