using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Termo.Core.Models.Email;
using Termo.Data.Models;

namespace Termo.Controllers
{
    [Route("api/submit-test")]
    [ApiController]
    public class SubmitTestController : ControllerBase
    {
        [HttpPost]
        [Route("chair-lamp")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<JsonResult> chair_lamp(ChairLampTest chairLampTests)
        {
            return null;
        }
        [HttpPost]
        [Route("toulouse-pieron")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<JsonResult> toulouse_pieron()
        {
            return null;
        }
    }
}
