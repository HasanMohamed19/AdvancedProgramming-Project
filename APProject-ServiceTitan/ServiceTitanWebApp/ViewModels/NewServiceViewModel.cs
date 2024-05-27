#nullable disable
using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class NewServiceViewModel
    {
        public Service Service { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ApplicationUser> Technicians { get; set; }
        public List<int> TechniciansId { get; set; }
    }
}
