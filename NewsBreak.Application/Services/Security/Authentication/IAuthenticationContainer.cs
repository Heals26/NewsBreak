using System.Security.Claims;

namespace NewsBreak.Application.Services.Security.Authentication
{

    public interface IAuthenticationContainer
    {

        string SecretKey { get; set; }
        string SecurityAlgorithm { get; set; }
        int ExpireMinutes { get; set; }

        Claim[] Claims { get; set; }

    }

}
