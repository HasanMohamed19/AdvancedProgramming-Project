#nullable disable
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class NewUserViewModel
    {
        // new user
        public ApplicationUser NewUser { get; set; }
        public int CategoryId { get; set; }
        // lists for technicans
        public IEnumerable<int> AssignedServicesIds { get; set; }
        

        public IEnumerable<Category> Categories { get; set; }

        public MultiSelectList Services { get; set; }

    }
}
