using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Termo.Core.Repositories.Interfaces;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Termo.Core.Models.Email;
using Microsoft.Extensions.Configuration;
using System;

namespace Termo.Core.Repositories
{
    public class MailSender : IMailSender
    {
        private readonly IEmailSender _sender;
        private readonly IHostEnvironment _environment;
        private readonly ILogger<MailSender> _logger;
        private readonly IHttpContextAccessor httpContext;
        private readonly IConfiguration _configuration;

        public MailSender(IEmailSender _sender,
            IHostEnvironment _environment, ILogger<MailSender> _logger,
            IHttpContextAccessor httpContext, IConfiguration _configuration)
        {
            this._sender = _sender;
            this._environment = _environment;
            this._logger = _logger;
            this.httpContext = httpContext;
            this._configuration = _configuration;
        }
        public async Task<bool> SendMessageAsync(MailDto model)
        {
            try
            {
                StringBuilder htmlMessage = new();
                using (StreamReader sr = new StreamReader(Path.Combine(_environment.ContentRootPath, "Email", "Links.html")))
                {
                    htmlMessage.Append(await sr.ReadToEndAsync());
                }
                htmlMessage.Replace("[Felado]", $"Üdv {model.LastName} {model.FirstName}!");
                htmlMessage.Replace("[Uzenet]", "Link ami generálva lesz");
                await _sender.SendEmailAsync(model.Email, "Üdvözlünk a játékban", htmlMessage.ToString());
                _logger.LogWarning($"SendEmailAsync [Success]");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"SendEmailAsync [Failed] {ex.Message}");
                return false;
            }

        }
    }
}
