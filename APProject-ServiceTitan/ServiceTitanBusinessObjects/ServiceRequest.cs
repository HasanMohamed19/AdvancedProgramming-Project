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
        public int RequestPrice { get; set; }

        [Required]
        [Column("request_date_needed")]
        public DateTime RequestDateNeeded { get; set; }

        [Required]
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }

        [Required]
        public Service Service { get; set; }

        [Required]
        public RequestStatus Status { get; set; }


    }
}
