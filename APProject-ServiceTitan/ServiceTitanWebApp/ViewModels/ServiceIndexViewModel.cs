using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class ServiceIndexViewModel
    {

        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Service>? Services { get; set; }

        public string? searchName { get; set; }
        public string? searchManager { get; set; }

    }
}
