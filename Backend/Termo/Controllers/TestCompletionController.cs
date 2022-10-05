using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Termo.Core.Models;
using Termo.Core.Models.Email;
using Termo.Core.Repositories.Interfaces;

namespace Termo.Controllers
{
    [Route("api/test-completion/")]
    [ApiController]
    public class TestCompletionController : ControllerBase
    {
        private readonly IToulousePieronRepository pieronRepository;
        private readonly IChairLampRepository chairLampRepository;
        private readonly IBourdonRepository bourdonRepository;

        public TestCompletionController(IToulousePieronRepository pieronRepository,
            IChairLampRepository chairLampRepository, IBourdonRepository bourdonRepository)
        {
            this.pieronRepository = pieronRepository;
            this.chairLampRepository = chairLampRepository;
            this.bourdonRepository = bourdonRepository;
        }

        [HttpPost]
        [Route("toulouse-pieron")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<JsonResult> toulouse_pieron(BaseDto dto)
        {
            try
            {
                return new JsonResult(new { isCompleted = await pieronRepository.IsInValidTest(dto.Token)});
            }
            catch (Exception)
            {
                return new JsonResult(new { isCompleted = false });
            }
        }

        [HttpPost]
        [Route("bourdon")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<JsonResult> bourdon(BaseDto dto)
        {
            try
            {
                return new JsonResult(new { isCompleted = await bourdonRepository.IsInValidTest(dto.Token)});
            }
            catch (Exception)
            {
                return new JsonResult(new { isCompleted = false });
            }
        }

        [HttpPost]
        [Route("chair-lamp")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<JsonResult> chair_lamp(BaseDto dto)
        {
            try
            {
                return new JsonResult(new { isCompleted = await chairLampRepository.IsInValidTest(dto.Token)});
            }
            catch (Exception)
            {
                return new JsonResult(new { isCompleted = false });
            }
        }
    }
}
