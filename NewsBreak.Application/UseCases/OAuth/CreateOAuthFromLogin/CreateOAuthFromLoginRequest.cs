using MediatR;

namespace NewsBreak.Application.UseCases.OAuth.CreateOAuthFromLogin
{

    public class CreateOAuthFromLoginRequest : IRequest<CreateOAuthFromLoginResponse>
    {

        #region Properties

        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public string Password { get; set; }
        public string RedirectUrl { get; set; }
        public string Scope { get; set; }
        public string Username { get; set; }

        #endregion Properties

    }

}
