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
        [Column("service_request")]
        public int RequestID { get; set; }

        //[Required]
        [MaxLength(50)]
        [Column("request_description")]
        public string RequestDescription { get; set; }

        [Required]
        [Column("request_price")]
        public int RequestPrice { get; set; }

        [Required]
        [Column("request_date_needed")]
        public DateTime RequestDateNeeded { get; set; }




    }
}
