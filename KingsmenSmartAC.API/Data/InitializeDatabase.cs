using System;
using System.Linq;
using System.Threading.Tasks;
using KingsmenSmartAC.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KingsmenSmartAC.API.Data
{
    public static class InitializeDatabase
    {
        private const string Password = "Password1!";
        private static readonly Random RandomGenerator = new Random();


        public static async Task InitializeApplication(IServiceProvider serviceProvider)
        {
            await using var context =
                new ApplicationContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationContext>>());
            // Check if any devices exist, if so, then don't do anything
            if (context.Devices.Any())
            {
                return;
            }

            var devices = new Device[200];
            for (var i = 0; i < devices.Length; i++)
            {
                var firmwareVersions = new[]
                {
                    $"1.0.{RandomGenerator.Next(10000, 20000)}",
                    $"1.0.{RandomGenerator.Next(10000, 20000)}",
                    $"1.0.{RandomGenerator.Next(20000, 25000)}",
                    $"1.0.{RandomGenerator.Next(30000, 35000)}",
                    $"1.0.{RandomGenerator.Next(30000, 35000)}",
                    $"1.0.{RandomGenerator.Next(10000, 35000)}",
                };
                var device = new Device
                {
                    SerialNumber = Guid.NewGuid().ToString("N").Substring(0, 12),
                    FirmwareVersion = firmwareVersions[RandomGenerator.Next(0, 5)],
                    Temperature = RandomGenerator.Next(30, 100),
                    COLevel = RandomGenerator.Next(1, 12),
                    Humidity = RandomGenerator.Next(30, 80),
                    HealthStatus = (HealthStatus) RandomGenerator.Next(3)
                };

                devices[i] = device;
            }

            await context.Devices.AddRangeAsync(devices);
            await context.SaveChangesAsync();
        }
    }
}