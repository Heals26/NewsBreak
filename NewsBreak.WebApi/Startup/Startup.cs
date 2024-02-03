using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsBreak.Infrastructure.HttpGateways;
using NewsBreak.Persistence.Data;
using NewsBreak.WebApi.Infrastructure.Configuration;

namespace NewsBreak.WebApi.Startup
{

    public class Startup
    {

        #region Constructors

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            //this.KeyManager = keyManager;
        }

        #endregion Constructors

        #region Properties

        public IConfiguration Configuration { get; }
        //public IKeyManager KeyManager { get; }

        #endregion Properties

        #region Methods

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddOptions();
            this.ConfigureAppContextSettings(services);

            services.AddSecurityServices(this.Configuration);
            services.AddInterfaces();
        }

        public void Configure(IApplicationBuilder app, PersistenceContext persistenceContext)
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "News Break");
                s.EnableFilter();
            });

            _ = app.UseDeveloperExceptionPage();

            _ = app.UseHttpsRedirection();
            _ = app.UseRouting();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();
            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });

            persistenceContext.Database.Migrate();
        }

        public void ConfigureAppContextSettings(IServiceCollection services)
        {
            _ = services.Configure<DataStorageOptions>(this.Configuration.GetSection("DataStorageSettings"));
        }

        private void AddHttpClients(IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddHttpClient<LifxHttpGateway>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.lifx.com/v1", UriKind.Absolute);
                //httpClient.DefaultRequestHeaders.Add("Authorization", this.KeyManager.GetSecret("lifxBearerToken"));
            });

            // Register SteelSeries address
            // C:\ProgramData\SteelSeries\SteelSeries Engine 3
        }

        #endregion Methods

    }

}
