using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Termo.Core.Models.Email;
using Termo.Core.Repositories.Interfaces;

namespace Termo.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IMailSender mailService;

        public DefaultController(IMailSender mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<JsonResult> Send(MailDto mailDto)
        {
            try
            {
                return new JsonResult(new { success = await mailService.SendMessageAsync(mailDto) });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = ex.Message });
            }
        }
    }
}
