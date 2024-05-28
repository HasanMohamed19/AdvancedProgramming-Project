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
        [Display(Name = "Message")]
        public string NotificationMessage { get; set; }

        [Column("notification_title")]
        [MaxLength(100)]
        [Display(Name = "Title")]
        public string NotificationTitle { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("notification_type")]
        [Display(Name = "Type")]
        public string NotificationType { get; set; }


        [Display(Name = "Status")]
        public int NotificationStatusId { get; set; }

        [Column("notification_status")]
        [Display(Name = "Status")]
        public NotificationStatus? NotificationStatus { get; set; }


        [Display(Name = "User")]
        public int? UserId { get; set; }
        [Display(Name = "User")]
        public ApplicationUser? User { get; set; }
    }
}
