using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Termo.Core.Models;
using Termo.Core.Models.Email;
using Termo.Core.Models.ToulousePieron;
using Termo.Core.Repositories.Interfaces;
using Termo.Data.Models;

namespace Termo.Controllers
{
    [Route("api/submit-test")]
    [ApiController]
    public class SubmitTestController : ControllerBase
    {
        private readonly IToulousePieronRepository pieronRepository;

        public SubmitTestController(IToulousePieronRepository pieronRepository)
        {
            this.pieronRepository = pieronRepository;
        }

        [HttpPost]
        [Route("chair-lamp")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> chair_lamp(ChairLampTest chairLampTests)
        {
            return Ok();
        }

        [HttpPost]
        [Route("toulouse-pieron")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> toulouse_pieron(ToulousePieronDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RequestM { StatusCode = StatusCodes.Status400BadRequest, Message = "ModelState Invalid" });
            }
            return Ok(await pieronRepository.Save(dto));
        }

        [HttpPost]
        [Route("bourdon")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> bourdon(BourdonTest dto)
        {
            return Ok();
        }
    }
}
