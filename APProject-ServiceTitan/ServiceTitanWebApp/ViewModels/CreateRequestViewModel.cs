using ServiceTitanBusinessObjects;
namespace ServiceTitanWebApp.ViewModels
{
    public class CreateRequestViewModel
    {
        public Service? Service { get; set; }
        public ServiceRequest? Request { get; set; }
        public int? ServiceId { get; set; }
    }
}
