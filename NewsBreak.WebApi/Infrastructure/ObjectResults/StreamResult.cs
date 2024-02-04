using Microsoft.AspNetCore.Mvc;

namespace NewsBreak.WebApi.Infrastructure.ObjectResults
{

    public class StreamResult : FileStreamResult
    {

        #region - - - - - - Constructors - - - - - -

        public StreamResult(Stream fileStream, string contentType) : base(fileStream, contentType)
        {

        }

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        public string FileName { get; set; }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (!string.IsNullOrWhiteSpace(this.FileName))
                context.HttpContext.Response.Headers.Add("Content-Disposition", $"application; fileName=\"{this.FileName}\"");

            return base.ExecuteResultAsync(context);
        }

        #endregion Methods

    }

}
