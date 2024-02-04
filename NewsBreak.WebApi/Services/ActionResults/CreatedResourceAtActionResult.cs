using Microsoft.AspNetCore.Mvc;

namespace NewsBreak.WebApi.Services.ActionResults
{
    public class CreatedResourceAtActionResult : CreatedAtActionResult, ICreatedResourceResult
    {

        #region - - - - - - Constructors - - - - - -

        public CreatedResourceAtActionResult(long resourceID, string actionName, string controllerName, object routeValues, object value)
            : base(actionName, controllerName, routeValues, value)
        {
            this.ResourceID = resourceID;
        }

        #endregion

        #region - - - - - - Properties - - - - - -

        public long ResourceID { get; }

        #endregion Properties

    }

}
