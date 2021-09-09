using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.DataAccess;
using Microsoft.AspNetCore;
using System.IO;

namespace Master.WebApp
{
    public class Program
    {
        private static string Namespace = typeof(Startup).Namespace;
#pragma warning disable IDE0057 // Use range operator
        public static string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
#pragma warning restore IDE0057 // Use range operator

        private static string EnvName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            Log.Logger = CreateSerilogLogger(configuration);

            Log.Information($"Current environment is {EnvName}");

            try
            {
                Log.Information("Configuring web host ({ApplicationContext})...", AppName);
                var host = BuildWebHost(configuration, args);

                Log.Information("Applying migrations ({ApplicationContext})...", AppName);

                host.MigrateDbContext<MasterContext>((_, _) => { });

                Log.Information("Starting web host ({ApplicationContext})...", AppName);
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(false)
                .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSerilog()
                .Build();

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{EnvName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        private static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
        {
            return new LoggerConfiguration()
                .Enrich.WithProperty("ApplicationContext", AppName)
                .WriteTo.Console()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
    }
}
