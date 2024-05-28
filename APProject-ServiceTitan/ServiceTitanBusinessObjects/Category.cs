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
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Column("category_description")]
        [Display(Name = "Description")]
        public string? CategoryDescription { get; set; }

        [Display(Name = "Manager")]
        public int? CategoryManagerId { get; set; }
        [Column("category_manager_id")]
        [Display(Name = "Manager")]
        public ApplicationUser? CategoryManager { get; set; }

        public ICollection<Service> Services { get; } = new HashSet<Service>();
    }
}
