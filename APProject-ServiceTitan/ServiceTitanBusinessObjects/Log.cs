using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("log_id")]
        public int LogID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Source { get; set; }

        [Required]
        public DateTime Time { get; set; }

        public string Message { get; set; }

        [Column("original_value")]
        public string OriginalValue { get; set; }

        [Column("current_value")]
        public string CurrentValue { get; set; }

        [Required]
        [MaxLength(10)]
        public string Type { get; set; }

        [Required]
        public User? User { get; set; }

    }
}
