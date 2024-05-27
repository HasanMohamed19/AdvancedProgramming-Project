#nullable disable
using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class NewCategoryViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
