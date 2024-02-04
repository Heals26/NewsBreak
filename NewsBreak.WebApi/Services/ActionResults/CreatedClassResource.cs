using Microsoft.AspNetCore.Mvc;

namespace NewsBreak.WebApi.Services.ActionResults
{

    public class CreatedClassResource : CreatedResult, ICreatedResourceResult
    {

        #region - - - - - - Constructor - - - - - -

        public CreatedClassResource(string location, long resourceID, object value) : base(location, value)
            => this.ResourceID = resourceID;

        #endregion Constructor

        #region - - - - - - Properties - - - - - -

        public long ResourceID { get; private set; }

        #endregion Properties

    }

}
