using Microsoft.Extensions.DependencyInjection;
using NewsBreak.Application.Infrastructure.Validation;
using NewsBreak.Application.Services.Validation;
using NewsBreak.Infrastructure.Persistence;
using NewsBreak.Infrastructure.Services;

namespace NewsBreak.WebApi.Startup
{

    public static class RegisterInterfaces
    {

        public static void AddInterfaces(this IServiceCollection services)
        {
            services.AddAuthenticationInterfaces();
            services.AddPipelineInterfaces();
            services.AddInfrastructureInterfaces();
        }

        public static void AddAuthenticationInterfaces(this IServiceCollection services)
        {

        }

        public static void AddInfrastructureInterfaces(this IServiceCollection services)
        {
            _ = services.AddScoped<IKeyManager, KeyManager>();
        }

        public static void AddPipelineInterfaces(this IServiceCollection services)
        {
            _ = services.AddScoped<IEntityExistenceChecker, EntityExistenceChecker>();

        }

    }

}
