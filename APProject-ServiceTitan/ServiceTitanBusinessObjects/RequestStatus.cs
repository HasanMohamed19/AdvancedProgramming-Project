using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class RequestStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("request_status_id")]
        public int StatusID { get; set; }

        [Required]
        [MaxLength(15)]
        [Column("request_status")]
        public string Status { get; set; }

        public ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
