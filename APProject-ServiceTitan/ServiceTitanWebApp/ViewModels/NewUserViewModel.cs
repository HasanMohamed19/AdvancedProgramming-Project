#nullable disable
using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class NewUserViewModel
    {
        // new user
        public ApplicationUser NewUser { get; set; }
        public int CategoryId { get; set; }
        public int ServiceId { get; set; }
        

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Service> Services { get; set; }


    }
}
