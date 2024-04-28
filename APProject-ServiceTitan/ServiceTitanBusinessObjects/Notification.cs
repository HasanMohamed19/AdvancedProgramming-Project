using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class Notification
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("notification_id")]
        public int NotificationID { get; set; }

        [Column("notification_message")]
        public string NotificationMessage { get; set; }

        [Column("notification_title")]
        [MaxLength(100)]
        public string NotificationTitle { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("notification_type")]
        public string NotificationType { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("notification_status")]
        public string NotificationStatus { get; set; }

        [Required]
        [Column("user_id")]
        public User User { get; set; }
    }
}
