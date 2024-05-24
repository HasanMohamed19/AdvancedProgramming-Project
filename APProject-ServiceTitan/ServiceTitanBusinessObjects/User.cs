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
        public UserRole? Role { get; set; }

        public ICollection<Category> Categories { get; } = new HashSet<Category>();

        public ICollection<ServiceTechnician> ServiceTechnicians { get; } = new HashSet<ServiceTechnician>();
        public ICollection<Service> Services { get; } = new HashSet<Service>();

        public ICollection<ServiceRequest> ClientServiceRequests { get; } = new HashSet<ServiceRequest>();
        public ICollection<ServiceRequest> TechnicianServiceRequests { get;} = new HashSet<ServiceRequest>();

        public ICollection<Notification> Notifications { get; } = new HashSet<Notification>();

        public ICollection<Comment> Comments { get; } = new HashSet<Comment>();

        public ICollection<Document> Documents { get; } = new HashSet<Document>();

        public ICollection<Log> Logs { get; } = new HashSet<Log>();

        public override string? ToString()
        {
            return UserName;
        }
    }
}
