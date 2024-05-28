using ServiceTitanBusinessObjects;

namespace ServiceTitanWebApp.ViewModels
{
    public class LogIndexViewModel
    {
        public List<string>? LogTypes { get; set; }
        public IEnumerable<Log>? Logs { get; set; }

        public string? searchLogType { get; set; }
        public string? searchUser { get; set; }
    }
}
