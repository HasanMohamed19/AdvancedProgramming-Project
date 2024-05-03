using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitanBusinessObjects
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("category_id")]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("category_name")]
        public string CategoryName { get; set; }

        [Column("category_description")]
        public string? CategoryDescription { get; set; }

        public int? CategoryManagerId { get; set; }
        // if category manager gets deleted, category should not delete
        // which makes manager optional
        [Column("category_manager_id")]
        public User? CategoryManager { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
