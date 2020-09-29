using System;
using System.Linq;
using System.Threading.Tasks;
using KingsmenSmartAC.API.Helpers;
using KingsmenSmartAC.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KingsmenSmartAC.API.Data
{
    public class InitializeDatabase
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

            var devices = new Device[20];
            for (var i = 0; i < devices.Length; i++)
            {
                var device = new Device
                {
                    SerialNumber = Guid.NewGuid().ToString("N").Substring(0, 12),
                    FirmwareVersion = $"1.0.{RandomGenerator.Next(10000, 35000)}"
                };

                devices[i] = device;
            }

            await context.Devices.AddRangeAsync(devices);
            var updates = await context.SaveChangesAsync();
            if (updates == 0)
            {
                return;
            }

            // add some reports for each device
            var allDevices = await context.Devices.ToListAsync();
            foreach (var device in allDevices)
            {
                var reports = new DeviceReport[RandomGenerator.Next(1, 5)];
                for (var i = 0; i < reports.Length; i++)
                {
                    var report = new DeviceReport
                    {
                        DeviceId = device.DeviceId,
                        Temperature = RandomGenerator.Next(30,100),
                        COLevel = RandomGenerator.Next(1, 12),
                        Humidity = RandomGenerator.Next(30, 80),
                        HealthStatus = (HealthStatus) RandomGenerator.Next(3)
                    };
                    reports[i] = report;
                }

                context.DeviceReports.AddRange(reports);
            }

            updates = await context.SaveChangesAsync();
            if (updates == 0)
            {
                return;
            }

            // Generate any necessary notifications
            var allReports = await context.DeviceReports.ToListAsync();

            foreach (var report in allReports)
            {
                await NotificationHelper.GenerateNotifications(report, context);
            }
        }
    }
}