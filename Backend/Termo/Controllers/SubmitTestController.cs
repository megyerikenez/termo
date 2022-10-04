using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Termo.Core.Models;
using Termo.Core.Models.ChairLamp;
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
        private readonly IChairLampRepository chairLampRepository;

        public SubmitTestController(IToulousePieronRepository pieronRepository, 
            IChairLampRepository chairLampRepository)
        {
            this.pieronRepository = pieronRepository;
            this.chairLampRepository = chairLampRepository;
        }

        [HttpPost]
        [Route("chair-lamp")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> chair_lamp(ChairLampDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RequestM { StatusCode = StatusCodes.Status400BadRequest, Message = "ModelState Invalid" });
            }
            return await chairLampRepository.Save(dto);
        }

        [HttpPost]
        [Route("toulouse-pieron")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> toulouse_pieron(ToulousePieronDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new RequestM { StatusCode = StatusCodes.Status400BadRequest, Message = "ModelState Invalid" });
            }
            return await pieronRepository.Save(dto);
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
