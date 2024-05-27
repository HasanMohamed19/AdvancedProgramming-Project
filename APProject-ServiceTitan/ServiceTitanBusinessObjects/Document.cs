using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("document_id")]
        public int DocumentID { get; set; }

        [Required]
        [Column("document_name")]
        [MaxLength(200)]
        public string DocumentName { get; set; }


        public string? DocumentDescription { get; set; }

        [Required]
        [Column("document_upload_date")]
        public DateTime DocumentUploadDate { get; set; }

        [Required]
        [Column("document_type")]
        [MaxLength(20)]
        public string DocumentType { get; set; }

        [Required]
        [Column("document_path")]
        public string DocumentPath { get; set; }
        public int? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int? ServiceRequestId { get; set; }
        public ServiceRequest? Request { get; set; }
    }
}
