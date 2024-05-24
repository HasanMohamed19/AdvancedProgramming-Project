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
    public class ServiceRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("request_id")]
        public int RequestID { get; set; }

        //[Required]
        [Column("request_description")]
        public string RequestDescription { get; set; }

        [Required]
        [Column("request_price")]
        public decimal RequestPrice { get; set; }

        [Required]
        [Column("request_date_needed")]
        public DateTime RequestDateNeeded { get; set; }

        public int? ClientId { get; set; }
        public ApplicationUser? Client { get; set; }

        public int? TechnicianId { get; set; }
        public ApplicationUser? Technician { get; set; }

        public ICollection<Comment> Comments { get; } = new HashSet<Comment>();

        public int? ServiceId { get; set; }
        public Service? Service { get; set; }

        public int? StatusId { get; set; }
        public RequestStatus? Status { get; set; }


    }
}
