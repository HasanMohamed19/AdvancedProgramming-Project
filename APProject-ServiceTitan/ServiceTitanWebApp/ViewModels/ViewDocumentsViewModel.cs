using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class ViewDocumentsViewModel
    {
        public IEnumerable<Document> Documents { get; set; }
        public int? RequestId { get; set; }
    }
}
