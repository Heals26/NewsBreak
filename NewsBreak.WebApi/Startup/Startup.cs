using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsBreak.WebApi.Infrastructure.Configuration;

namespace NewsBreak.WebApi.Startup
{

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigureAppContextSettings(services);

            services.AddSecurityServices();
            services.AddInterfaces();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "News Break");
                s.EnableFilter();
            });

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureAppContextSettings(IServiceCollection services)
        {
            services.Configure<DataStorageOptions>(this.Configuration.GetSection("DataStorageSettings"));
        }

    }

}
