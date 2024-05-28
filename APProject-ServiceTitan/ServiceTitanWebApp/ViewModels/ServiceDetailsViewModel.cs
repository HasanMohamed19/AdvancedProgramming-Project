using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class ServiceDetailsViewModel
    {
        public Service Service { get; set; } = null!;
        public IEnumerable<ApplicationUser> Technicians { get; set; } = null!;
    }
}
