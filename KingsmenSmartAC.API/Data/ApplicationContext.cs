using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingsmenSmartAC.API.Models;

namespace KingsmenSmartAC.API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        // Tables
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceReport> DeviceReports { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Set default date & time values for model objects.
            builder.Entity<Device>().Property(device => device.CreatedDateTime).HasDefaultValueSql("GETUTCDATE()");
            builder.Entity<Device>().Property(device => device.UpdatedDateTime).HasDefaultValueSql("GETUTCDATE()");
            builder.Entity<DeviceReport>().HasKey(report => report.ReportID);
            builder.Entity<DeviceReport>().Property(device => device.CreatedDateTime)
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Entity<Notification>().Property(n => n.CreatedDateTime).HasDefaultValueSql("GETUTCDATE()");
            builder.Entity<Notification>().Property(n => n.UpdatedDateTime).HasDefaultValueSql("GETUTCDATE()");
            builder.Entity<Notification>().Property(n => n.Status).HasDefaultValue(NotificationStatus.New);
        }

        public DbSet<KingsmenSmartAC.API.Models.Notification> Notification { get; set; }
    }
}