using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewsBreak.WebApi.Services.OutputPortPresenters
{

    public class ForbiddenObjectResult : ObjectResult
    {

        #region - - - - - - Constructors - - - - - -

        public ForbiddenObjectResult(object problemDetails) : base(problemDetails) { this.StatusCode = StatusCodes.Status403Forbidden; }

        #endregion Constructors

    }

}
