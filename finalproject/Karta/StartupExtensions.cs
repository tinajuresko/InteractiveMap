using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Karta.Model;
using Karta;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Karta
{
  public static class StartupExtensions
  {
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
            //ovo je prije pisalo
            /*var appSection = builder.Configuration.GetSection("AppSettings");
            builder.Services.Configure<AppSettings>(appSection);
            builder.Services.AddDbContext<Rppp06Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyPostgreSQLDatabase")));
            builder.Services.AddControllersWithViews();
            return builder.Build();*/

            // Add logging
            builder.Services.AddLogging(logging =>
            {
                logging.ClearProviders(); // Optional: Clears any default logging providers
                logging.AddConsole();     // Adds logging to the console
                                          // Add more logging providers if needed, such as logging to a file or a third-party service
            });

            //ovo sam dodala
            var appSection = builder.Configuration.GetSection("AppSettings");
            builder.Services.Configure<AppSettings>(appSection);
            builder.Services.AddDbContext<KartaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyPostgreSQLDatabase")));
            builder.Services.AddControllersWithViews();

            

            return builder.Build();
        }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
      #region Needed for nginx and Kestrel (do not remove or change this region)
      app.UseForwardedHeaders(new ForwardedHeadersOptions
      {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                           ForwardedHeaders.XForwardedProto
      });
      string pathBase = app.Configuration["PathBase"];
      if (!string.IsNullOrWhiteSpace(pathBase))
      {
        app.UsePathBase(pathBase);
      }
      #endregion

      if (app.Environment.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles()
         .UseRouting()
         .UseEndpoints(endpoints =>
         {
           endpoints.MapDefaultControllerRoute();
         });

      return app;
    }
  }
}