using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class UploadFilesViewModel
    {
        public List<Document> Documents { get; set; }
        public int? ServiceRequestId { get; set; }
    }
}
