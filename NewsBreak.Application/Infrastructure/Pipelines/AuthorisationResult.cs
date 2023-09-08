using CleanArchitecture.Mediator;

namespace NewsBreak.Application.Infrastructure.Pipelines
{

    public class AuthorisationResult : IAuthorisationResult
    {

        #region - - - - - - Constructors - - - - - -

        private AuthorisationResult() { }

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        public string FailureReason { get; set; }

        public bool IsAuthorised
            => string.IsNullOrEmpty(this.FailureReason);

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        public static AuthorisationResult Failure()
            => new() { FailureReason = "You are not authorised to perform this action" };

        public static AuthorisationResult Failure(string failureReason)
            => new() { FailureReason = failureReason };

        public static AuthorisationResult Success()
            => new();

        #endregion Methods

    }

}
