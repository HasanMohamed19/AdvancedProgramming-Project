using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class CategoryIndexViewModel
    {

        public IEnumerable<ApplicationUser>? Managers { get; set; }
        public IEnumerable<Category>? Categories { get; set; }

        public int? ManagerCategoryId { get; set; }
        public string? searchName { get; set; }
        public string? searchManager { get; set; }

    }
}
