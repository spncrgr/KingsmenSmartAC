using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KingsmenSmartAC.API.Models
{
    public enum NotificationStatus
    {
        New,
        Acknowledged,
        Resolved
    }

    public class Notification
    {
        [Display(Name = "Notification ID")] public long NotificationID { get; set; }

        [MaxLength(256)]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        [Display(Name = "Created")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }

        [Display(Name = "Updated")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDateTime { get; set; }

        public NotificationStatus Status { get; set; }

        // Relationship Properties
        public DeviceReport DeviceReport { get; set; }
        public Device Device { get; set; }
    }
}