using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public enum UserRole
    {
        admin = 1,
        manager = 2,
        technician = 3,
        client = 4
    }
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("username")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        [Column ("email")]
        [RegularExpression("#emailregexgoeshere")]
        public string UserEmail { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("password")]
        public string Password { get; set; }


    }
}
