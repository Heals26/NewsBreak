using Microsoft.IdentityModel.Tokens;
using NewsBreak.Application.Services.Security.Authentication;
using System.Security.Claims;

namespace NewsBreak.Application.Security.Authentication
{

    public class AuthenticationContainer : IAuthenticationContainer
    {

        #region Properties

        public int ExpireMinutes { get; set; } = 10080;
        public string SecretKey { get; set; } = "Make this secure, lmao";
        public string SecurityAlgorithm { get; set; } = SecurityAlgorithms.HmacSha256Signature;

        public Claim[] Claims { get; set; }

        #endregion Properties

    }

}
