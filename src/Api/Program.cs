using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Api
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                .Build();

            var log = host.Services.GetRequiredService<ILogger<Program>>();
            log.LogInformation("Starting web host ...");

            try
            {
                host.Run();
            }
            catch (Exception ex)
            {
                log.LogCritical(ex, "Host terminated unexpectedly.");
                return -1;
            }

            log.LogInformation("Host closing ...");

            return 0;
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();
        }
    }
}
