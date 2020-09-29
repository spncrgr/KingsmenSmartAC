using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingsmenSmartAC.API.Models
{
    public enum HealthStatus
    {
        Ok,
        NeedsService,
        NeedsNewFilter,
        GasLeak
    }

    public class DeviceReport
    {
        public long DeviceReportId { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal COLevel { get; set; }
        public HealthStatus HealthStatus { get; set; }

        public long DeviceId { get; set; }
    }
}