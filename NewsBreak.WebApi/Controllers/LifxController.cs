using Microsoft.AspNetCore.Mvc;
using NewsBreak.WebApi.UseCases.Lifx.SetState;

namespace NewsBreak.WebApi.Controllers
{

    [Route("[controller]/v1")]
    public class LifxController : BaseController
    {

        #region Lights

        [HttpPut("/lights/all/state")]
        public async Task<IActionResult> SetLightState([FromBody] SetStateApiRequest request)
        {
            return this.NoContent();
        }

        #endregion Lights

    }

}
