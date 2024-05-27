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
        [Display(Name = "ID")]
        public int RequestID { get; set; }

        //[Required]
        [Column("request_description")]
        [Display(Name = "Description")]
        public string RequestDescription { get; set; }

        [Required]
        [Column("request_price")]
        [Display(Name = "Price")]
        public decimal RequestPrice { get; set; }

        [Required]
        [Column("request_date_needed")]
        [Display(Name = "Date")]
        public DateTime RequestDateNeeded { get; set; }

        public int? ClientId { get; set; }
        [Display(Name = "Client")]
        public ApplicationUser? Client { get; set; }

        public int? TechnicianId { get; set; }
        [Display(Name = "Technician")]
        public ApplicationUser? Technician { get; set; }

        public ICollection<Comment> Comments { get; } = new HashSet<Comment>();

        public int? ServiceId { get; set; }
        [Display(Name = "Service")]
        public Service? Service { get; set; }

        public int? StatusId { get; set; }
        [Display(Name = "Status")]
        public RequestStatus? Status { get; set; }


    }
}
