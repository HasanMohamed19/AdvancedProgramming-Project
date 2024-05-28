using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class NotificationIndexViewModel
    {
        public IEnumerable<Notification>? Notifications { get; set; }
        public IList<NotificationStatus> StatusIds { get; set; }

        public int? StatusId { get; set; }
        public string? SearchQuery { get; set; }
    }
}
