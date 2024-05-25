namespace ServiceTitanWebApp.ViewModels
{
    public class CreateRequestViewModel
    {
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Price { get; set; }
        public string? ServiceName { get; set; }
        public int? ServiceId { get; set; }
    }
}
