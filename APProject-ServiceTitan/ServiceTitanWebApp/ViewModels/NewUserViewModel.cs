using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class NewUserViewModel
    {
        // new user
        public ApplicationUser NewUser { get; set; }
        public Category Category { get; set; }
        public Service Service { get; set; }
        

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Service> Services { get; set; }

        // make it generic for now
        public IEnumerable<ApplicationUser> Users { get; set; }

    }
}
