using Microsoft.IdentityModel.Tokens;
using NewsBreak.Application.Services.Security.Authentication;
using NewsBreak.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Authentication;
using System.Security.Claims;

namespace NewsBreak.Application.Security.Authentication
{

    public class AuthenticationService : IAuthenticationService
    {

        #region Constructors

        public AuthenticationService(string secretKey)
        {
            this.SecretKey = secretKey;
        }

        #endregion Constructors

        #region Properties

        public string SecretKey { get; set; }

        #endregion Properties

        #region Interface Implementation

        public Claim[] CalculateClaims(ICollection<ClientClaim> claims)
        {
            var _Claims = new List<Claim>();

            foreach (var _Claim in claims)
                _Claims.Add(new Claim(ClaimTypes.Name, _Claim.ClaimName));

            return _Claims.ToArray();
        }

        public string GenerateToken(IAuthenticationContainer model)
        {
            if (model == null || model.Claims == null || !model.Claims.Any())
                throw new ArgumentNullException("Arguments to create token are not valid");

            var _TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(model.Claims),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(model.ExpireMinutes)),
                SigningCredentials = new SigningCredentials(this.GetSymmetricSecurityKey(), model.SecurityAlgorithm)
            };

            var _TokenHandler = new JwtSecurityTokenHandler();
            var _SecurityToken = _TokenHandler.CreateToken(_TokenDescriptor);

            var _Token = _TokenHandler.WriteToken(_SecurityToken);

            return _Token;
        }

        public IEnumerable<Claim> GetTokenClaims(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException("Token is null or empty");

            var _ValidationParamters = this.GetTokenValidationParameters();
            var _TokenHandler = new JwtSecurityTokenHandler();

            try
            {
                return _TokenHandler.ValidateToken(token, _ValidationParamters, out SecurityToken _ValidatedToken).Claims;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsTokenValid(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException("Token is null or empty");

            var _ValidationParamters = this.GetTokenValidationParameters();
            var _TokenHandler = new JwtSecurityTokenHandler();

            try
            {
                _ = _TokenHandler.ValidateToken(token, _ValidationParamters, out SecurityToken _ValidatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion Interface Implementation

        #region Methods

        private SecurityKey GetSymmetricSecurityKey()
        {
            var _SymmetricKey = Convert.FromBase64String(this.SecretKey);
            return new SymmetricSecurityKey(_SymmetricKey);
        }

        private TokenValidationParameters GetTokenValidationParameters()
            => new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = this.GetSymmetricSecurityKey()
            };

        #endregion Methods

    }

}
