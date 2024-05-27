using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class ServiceRequestIndexViewModel
    {

        
        public IEnumerable<ApplicationUser>? Clients { get; set; }
        public IEnumerable<ApplicationUser>? Techinicans { get; set; }
        public IEnumerable<RequestStatus>? RequestStatuses { get; set; }
        public IEnumerable<ServiceRequest>? ServiceRequests { get; set; }

        
        public string? searchName { get; set; }
        public string? searchStatus { get; set; }

    }
}
