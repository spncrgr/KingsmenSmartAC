using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingsmenSmartAC.API.Models
{
    public class Device
    {
        public long DeviceID { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }

        [Display(Name = "Created")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }

        [Display(Name = "Updated")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDateTime { get; set; }

        public Guid APIKey { get; set; }
    }
}