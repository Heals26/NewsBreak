using Microsoft.Extensions.DependencyInjection;
using NewsBreak.Application.Security.Authentication;
using NewsBreak.Application.Services.Security.Authentication;

namespace NewsBreak.WebApi.Startup
{

    public static class RegisterInterfaces
    {

        public static void AddInterfaces(this IServiceCollection services)
        {
            services.AddAuthenticationInterfaces();
        }

        public static void AddAuthenticationInterfaces(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationContainer, AuthenticationContainer>();
        }

    }

}
