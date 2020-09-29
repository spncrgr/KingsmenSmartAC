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
        public long DeviceId { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }

        // Relationship properties
        public List<DeviceReport> DeviceReports { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}