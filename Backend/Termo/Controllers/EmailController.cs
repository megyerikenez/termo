using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Termo.Core.Models.Email;
using Termo.Core.Repositories.Interfaces;
using Termo.Services;

namespace Termo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailSender mailService;

        public EmailController(IMailSender mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost]
        [Route("Send")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<JsonResult> Send(MailDto mailDto)
        {
            try
            {
                return new JsonResult(new {success = await mailService.SendMessageAsync(mailDto) });
            }
            catch (Exception ex)
            {
                return new JsonResult(new {success = ex.Message});
            }

        }
    }
}
