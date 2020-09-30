using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingsmenSmartAC.API.Data;
using Microsoft.Extensions.DependencyInjection;
using Azure.Identity;

namespace KingsmenSmartAC.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var applicationContext = services.GetRequiredService<ApplicationContext>();
                var dbCreated = applicationContext.Database.EnsureCreated();

                if (!dbCreated)
                {
                    try
                    {
                        InitializeDatabase.InitializeApplication(services).Wait();
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while initializing the Database");
                        throw;
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var keyVaultEndpoint = new Uri("https://kingsmendemoappsvc.azurewebsites.net");
                    config.AddAzureKeyVault(
                        keyVaultEndpoint,
                        new DefaultAzureCredential());
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}