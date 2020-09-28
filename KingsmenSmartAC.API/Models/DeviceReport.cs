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
        public long ReportID { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal Temperature { get; set; }
        [Column(TypeName = "decimal(5,2)")] public decimal Humidity { get; set; }

        [Display(Name = "CO Level")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal COLevel { get; set; }

        [Display(Name = "Device ID")] public long DeviceID { get; set; }

        [Display(Name = "Created")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }

        public HealthStatus HealthStatus { get; set; }
    }
}