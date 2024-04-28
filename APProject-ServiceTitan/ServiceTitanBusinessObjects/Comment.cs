using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("comment_id")]
        public int CommentID { get; set; }

        [Required]
        [MaxLength(int.MaxValue)] // verify this
        [Column("comment_text")]
        public string CommentText { get; set; }

        [Required]
        [Column("comment_date")]
        public DateTime CommentDate { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public ServiceRequest ServiceRequest { get; set; }
    }
}
