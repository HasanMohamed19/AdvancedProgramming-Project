using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public enum UserRole
    {
        admin = 1,
        manager = 2,
        technician = 3,
        client = 4
    }
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

        [Required]
        [Column("role_id")]
        public UserRole RoleID { get; set; }

        public Category ManagerForCategory { get; set; }

        public ICollection<Service> Services { get; set; }

        public ICollection<ServiceRequest> ServiceRequests { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Document> Documents { get; set; }

        public ICollection<Log> Logs { get; set; }


    }
}
