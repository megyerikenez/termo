using Termo.Core.Models;
using System.Net.Mail;
using Termo.Core.Models.Email;
using static Termo.Core.Repositories.MailSender;

namespace Termo.Core.Repositories.Interfaces
{
    public interface IMailSender
    {
        Task<bool> SendMessageAsync(MailDto model);
    }
}
