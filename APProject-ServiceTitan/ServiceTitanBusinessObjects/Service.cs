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
        public float ServiceType { get; set; }

        [Required]
        public Category Category { get; set; }

        public ICollection<User> Technicians { get; set; }

        public ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
