using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("#emailregexgoeshere")]
        public string UserEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public int? RoleId { get; set; }
        public UserRole Role { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Service> Services { get; set; }

        public ICollection<ServiceRequest> ClientServiceRequests { get; set; }
        public ICollection<ServiceRequest> TechnicianServiceRequests { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Document> Documents { get; set; }

        public ICollection<Log> Logs { get; set; }


    }
}
