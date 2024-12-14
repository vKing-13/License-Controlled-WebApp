namespace License_Server.Models
{
    public class License
    {
        public Guid Id { get; set; }
        public required string LicenseKey { get; set; }
        public required LicenseLevel LicenseLevel { get; set; }
        public required DateTime ExpiryDate { get; set; }
        public required bool IsClaimed { get; set; }
        public string? UserID { get; set; }
    }
    public enum LicenseLevel
    {
        basic,
        standard,
        premium
    }
}
