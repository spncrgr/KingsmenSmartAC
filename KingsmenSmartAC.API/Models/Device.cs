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

    public class Device
    {
        public long DeviceId { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal Temperature { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal Humidity { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal COLevel { get; set; }
        public HealthStatus HealthStatus { get; set; }
    }
}