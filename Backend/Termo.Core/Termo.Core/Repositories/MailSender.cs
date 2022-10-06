using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Termo.Core.Repositories.Interfaces;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Termo.Core.Models.Email;
using Microsoft.Extensions.Configuration;
using System;
using Termo.Data.Models;
using Termo.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Termo.Core.Repositories
{
    public class MailSender : IMailSender
    {
        private readonly IEmailSender _sender;
        private readonly IHostEnvironment _environment;
        private readonly ILogger<MailSender> _logger;
        private readonly IHttpContextAccessor httpContext;
        private readonly IConfiguration _configuration;
        private readonly TermoDbContext context;
        private readonly IHttpClientFactory httpClient;

        public MailSender(IEmailSender _sender,
            IHostEnvironment _environment, ILogger<MailSender> _logger,
            IHttpContextAccessor httpContext, IConfiguration _configuration,
            TermoDbContext context, IHttpClientFactory httpClient)
        {
            this._sender = _sender;
            this._environment = _environment;
            this._logger = _logger;
            this.httpContext = httpContext;
            this._configuration = _configuration;
            this.context = context;
            this.httpClient = httpClient;
        }
        public async Task<bool> SendMessageAsync(MailDto model)
        {
            try
            {
                string link = await GenerateLink();
                StringBuilder htmlMessage = new();
                using (StreamReader sr = new StreamReader(Path.Combine(_environment.ContentRootPath, "Email", model.Lang.ToLower().Equals("hu")? "email.html" : "email_en.html")))
                {
                    htmlMessage.Append(await sr.ReadToEndAsync());
                }
                htmlMessage.Replace("[felhasznalo]", $"{model.LastName} {model.FirstName}");
                htmlMessage.Replace("[link]", $"http://salvavita.kess.hu/?token={link}");
                await _sender.SendEmailAsync(model.Email, "Üdvözlünk a játékban", htmlMessage.ToString());

                await context.Users.AddAsync(new User
                {
                    Email = model.Email,
                    LastName = model.LastName,
                    FirstName = model.FirstName
                });
                await context.SaveChangesAsync();
                var user = await context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
                if (user == null)
                {
                    return false;
                }
                await context.Tests.AddAsync(new Test
                {
                    UserId = user.Id,
                    Link = link
                });
                await context.SaveChangesAsync();
                _logger.LogWarning($"SendEmailAsync [Success]");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"SendEmailAsync [Failed] {ex.Message}");
                return false;
            }
        }
        private async Task<string> GenerateLink()
        {
            char[] letters = "abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            Random rand = new Random();

            string word = "";
            for (int i = 0; i < 100; i++)
            {
                word += letters[rand.Next(0, letters.Length - 1)];
            }
            if (await ExistsLink(word))
            {
                await GenerateLink();
            }
            return word;
        }
        private async Task<bool> ExistsLink(string Link)
        {
            return await context.Tests.Where(x=>x.Link == Link).AnyAsync();
        }
    }
}
