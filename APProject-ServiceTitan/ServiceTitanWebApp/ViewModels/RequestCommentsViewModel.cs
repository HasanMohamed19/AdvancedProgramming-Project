using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class RequestCommentsViewModel
    {
        public int? RequestId { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
