using NewsBreak.Domain.Entities;
using System.Security.Claims;

namespace NewsBreak.Application.Services.Security.Authentication
{

    public interface IAuthenticationService
    {

        string SecretKey { get; set; }

        bool IsTokenValid(string token);
        Claim[] CalculateClaims(ICollection<ClientClaim> claims);
        string GenerateToken(IAuthenticationContainer model);
        IEnumerable<Claim> GetTokenClaims(string token);


    }

}
