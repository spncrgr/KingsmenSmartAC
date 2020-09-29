using System.Threading.Tasks;
using KingsmenSmartAC.API.Data;
using KingsmenSmartAC.API.Models;

namespace KingsmenSmartAC.API.Helpers
{
    public static class NotificationHelper
    {
        public static async Task GenerateNotifications(DeviceReport deviceReport, ApplicationContext context)
        {
            // Health status is needs_service, needs_new_filter, gas_leak
            if (deviceReport.HealthStatus > 0)
            {
                var healthNotification = new Notification
                {
                    Device = context.Devices.Find(deviceReport.DeviceId),
                    ShortDescription = $"{deviceReport.HealthStatus} Alert from Device {deviceReport.DeviceId}",
                    Description = "Alert details here."
                };
                await context.Notifications.AddAsync(healthNotification);
            }
            // CO level above 9
            if (deviceReport.COLevel > (decimal)9.0)
            {
                var coLevelNotification = new Notification
                {
                    Device = context.Devices.Find(deviceReport.DeviceId),
                    ShortDescription = $"CO Level Alert from Device {deviceReport.DeviceId}",
                    Description = "Alert details here."
                };
                await context.Notifications.AddAsync(coLevelNotification);
            }

            await context.SaveChangesAsync();
        }

    }
}