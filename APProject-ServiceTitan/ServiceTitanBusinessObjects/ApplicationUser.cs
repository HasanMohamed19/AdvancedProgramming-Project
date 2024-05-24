using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class ApplicationUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string? LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string UserEmail { get; set; }

        public int? RoleId { get; set; }
        public UserRole? Role { get; set; }

        public Category? Category { get; set; }

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
            return UserEmail;
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    // validate firstname, lastname, and address for customers only
        //    if (RoleId == 4)
        //    {
        //        if (FirstName == null)
        //        {
        //            yield return new ValidationResult("First Name cannot be empty.", new[] { nameof(FirstName) });
        //        } else if (LastName == null)
        //        {
        //            yield return new ValidationResult("Last Name cannot be empty.", new[] { nameof(LastName) });
        //        } else if (Address == null)
        //        {
        //            yield return new ValidationResult("Address cannot be empty.", new[] { nameof(Address) });
        //        }
        //    }
        //}
    }
}
