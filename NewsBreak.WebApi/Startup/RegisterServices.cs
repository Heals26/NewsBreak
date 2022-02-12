using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using NewsBreak.Application.Infrastructure.Pipeline;
using NewsBreak.Application.Services.Data;
using NewsBreak.Persistence;
using NewsBreak.WebApi.Infrastructure.Configuration;
using Newtonsoft.Json.Serialization;

namespace NewsBreak.WebApi.Startup
{

    public static class RegisterServices
    {

        const string BASIC = "BASIC";
        const string BEARER = "BEARER";

        public static void AddSecurityServices(this IServiceCollection services)
        {
            services.AddAuthenticationServices();
            services.AddAuthorisationServices();
            services.AddMvcServices();
            services.AddSwaggerService();
        }

        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var _DataStorageOptions = configuration.GetSection("DataStorageSettings").Get<DataStorageOptions>();
            services.AddDbContext<IBreakDBContext, BreakDBContext>(options =>
            {
                options.UseSqlServer(_DataStorageOptions.DatabaseConnectionString, o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });
        }

        public static void AddAuthenticationServices(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {

            }).AddPolicyScheme(BASIC, "Basic", options =>
            {
                options.ForwardDefaultSelector = context =>
                {
                    context.Request.Headers.TryGetValue(HeaderNames.Authorization, out var _Authorization);

                    if (_Authorization.FirstOrDefault()?.StartsWith(BEARER) ?? false)
                        return BEARER;
                    return BASIC;
                };
            });
        }

        public static void AddAuthorisationServices(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                var _DefaultAuthPolicyBuilder = new AuthorizationPolicyBuilder(BEARER, BASIC)
                .RequireAuthenticatedUser();
                options.DefaultPolicy = _DefaultAuthPolicyBuilder.Build();
            });
        }

        public static void AddMvcServices(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                var _Policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(_Policy)); ;
            });
        }

        public static void AddPipelineServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BusinessRuleValidationBehaviour<,>));
        }

        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "News Break", Version = "v1" });
                c.CustomSchemaIds((type) => type.FullName);
            });
        }

    }

}
