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
        public long NotificationId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDateTime { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedDateTime { get; set; }

        public NotificationStatus Status { get; set; }

        // Relationship Properties
        public Device Device { get; set; }
    }
}