using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NewsBreak.WebApi.Startup;

CreateHebHostBuilder(args).Build().Run();

static IWebHostBuilder CreateHebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
    .ConfigureLogging((hostingContext, logging) =>
    {
        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
    })
    .UseStartup<Startup>()
    .UseKestrel(options => options.Limits.MaxRequestBodySize = 10000000000);