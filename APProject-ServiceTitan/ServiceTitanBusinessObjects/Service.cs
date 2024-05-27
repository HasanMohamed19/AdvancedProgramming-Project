using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("service_id")]
        public int ServiceID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("service_name")]
        public string ServiceName { get; set; }

        [Required]
        [Column("service_description")]
        public string ServiceDescription { get; set; }

        [Required]
        [Column("service_price")]
        public decimal ServicePrice { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; } = null!;

        public ICollection<ServiceTechnician> ServiceTechnicians { get;} = new HashSet<ServiceTechnician>();
        public ICollection<ApplicationUser> Technicians { get;} = new HashSet<ApplicationUser>();

        public ICollection<ServiceRequest> ServiceRequests { get; } = new HashSet<ServiceRequest>();
    }
}
