using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using NewsBreak.Application.Services.Persistence;
using NewsBreak.Persistence.Data;
using NewsBreak.WebApi.Infrastructure.Configuration;

namespace NewsBreak.WebApi.Startup
{

    public static class RegisterServices
    {

        const string BASIC = "Basic";
        const string BEARER = "Bearer";

        public static void AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthenticationServices();
            //services.AddAuthorisationServices();
            services.AddEntityFramework(configuration);
            services.AddMvcServices();
            services.AddSwaggerService();
        }

        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var _DataStorageOptions = configuration.GetSection("DataStorageSettings").Get<DataStorageOptions>();
            _ = services.AddDbContext<IPersistenceContext, PersistenceContext>(options =>
            {
                _ = options.UseSqlServer(_DataStorageOptions.DatabaseConnectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });
        }

        public static void AddAuthenticationServices(this IServiceCollection services)
        {
            _ = services.AddAuthentication(options =>
            {

            }).AddPolicyScheme(BASIC, "Basic", options =>
            {
                options.ForwardDefaultSelector = context =>
                {
                    _ = context.Request.Headers.TryGetValue(HeaderNames.Authorization, out var _Authorization);

                    if (_Authorization.FirstOrDefault()?.StartsWith(BEARER) ?? false)
                        return BEARER;
                    return BASIC;
                };
            });
        }

        public static void AddAuthorisationServices(this IServiceCollection services)
        {
            _ = services.AddAuthorization(options =>
            {
                var _DefaultAuthPolicyBuilder = new AuthorizationPolicyBuilder(BEARER, BASIC)
                .RequireAuthenticatedUser();
                options.DefaultPolicy = _DefaultAuthPolicyBuilder.Build();
            });
        }

        public static void AddMvcServices(this IServiceCollection services)
        {
            _ = services.AddControllers(options =>
            {
                var _Policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(_Policy));
                ;
            });
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            _ = services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "News Break", Version = "v1" });
                c.CustomSchemaIds((type) => type.FullName);
            });
        }

    }

}
