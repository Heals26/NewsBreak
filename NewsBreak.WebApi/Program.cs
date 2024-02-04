using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using NewsBreak.Persistence.Data;
using NewsBreak.WebApi.Infrastructure.Configuration;
using NewsBreak.WebApi.Startup;

var _Builder = WebApplication.CreateBuilder(args);

_Builder.Services.Configure<DataStorageOptions>(_Builder.Configuration.GetSection("DataStorageSettings"));
_Builder.Services.AddSecurityServices(_Builder.Configuration);
_Builder.Services.AddInterfaces();

var _App = _Builder.Build();

_ = _App.UseSwagger();
_ = _App.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "News Break");
    s.EnableFilter();
});

_ = _App.UseDeveloperExceptionPage();

_ = _App.UseHttpsRedirection();
_ = _App.UseRouting();
//_ = _App.UseAuthentication();
//_ = _App.UseAuthorization();
_ = _App.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

using var _Scope = _App.Services.CreateScope();
var _PersistenceContext = _Scope.ServiceProvider.GetService<PersistenceContext>();

if (_PersistenceContext != null)
{
    _PersistenceContext.Database.Migrate();
    _PersistenceContext.Dispose();
}

_App.Run();
