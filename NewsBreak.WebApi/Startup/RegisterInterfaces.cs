using Microsoft.Extensions.DependencyInjection;
using NewsBreak.Application.Infrastructure.Validation;
using NewsBreak.Application.Services.Validation;

namespace NewsBreak.WebApi.Startup
{

    public static class RegisterInterfaces
    {

        public static void AddInterfaces(this IServiceCollection services)
        {
            services.AddAuthenticationInterfaces();
            services.AddPipelineInterfaces();
        }

        public static void AddAuthenticationInterfaces(this IServiceCollection services)
        {

        }

        public static void AddPipelineInterfaces(this IServiceCollection services)
        {
            services.AddScoped<IEntityExistenceChecker, EntityExistenceChecker>();

        }

    }

}
