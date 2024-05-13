using NLog.Web;
using NLog;
using Karta;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Karta.Model;
using Microsoft.EntityFrameworkCore;

//NOTE: Add dependencies/services in StartupExtensions.cs and keep this file as-is

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup().GetCurrentClassLogger();

//dodala:
builder.Services.AddDbContext<KartaContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("MyPostgreSQLDatabase"))
    );

try
{
  logger.Debug("init main");

    builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);


    builder.Host.UseNLog(new NLogAspNetCoreOptions() { RemoveLoggerFactoryFilter = false });

  var app = builder.ConfigureServices().ConfigurePipeline();
  app.Run();
}
catch (Exception exception)
{
  // NLog: catch setup errors
  logger.Error(exception, "Stopped program because of exception");
  throw;
}
finally
{
  // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
  NLog.LogManager.Shutdown();
}

public partial class Program { }