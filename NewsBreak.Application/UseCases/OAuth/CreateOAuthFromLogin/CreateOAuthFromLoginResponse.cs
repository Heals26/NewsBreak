using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBreak.Application.UseCases.OAuth.CreateOAuthFromLogin
{

    public class CreateOAuthFromLoginResponse
    {

        #region Properties

        public string AccessToken { get; set; }
        public string RedirectUrl { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresIn { get; set; }
        public string Scopes { get; set; }

        #endregion Properties

    }

}
