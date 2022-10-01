using Termo.Core.Models;
using System.Net.Mail;
using Termo.Core.Models.Email;

namespace Termo.Core.Repositories.Interfaces
{
    public interface IMailSender
    {
        Task<bool> SendMessageAsync(MailDto model);
    }
}
