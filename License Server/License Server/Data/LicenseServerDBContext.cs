using Microsoft.EntityFrameworkCore;

namespace License_Server.Data
{
    public class LicenseServerDBContext : DbContext
    {
        public LicenseServerDBContext(DbContextOptions<LicenseServerDBContext> options) : base(options)
        {
        }
         
        public DbSet<License> Licenses { get; set; }
    }
    public class License 
    {
        public Guid Id {get; set; }
        public required string LicenseKey { get; set; }
        public required string LicenseLevel { get; set; }
        public required DateTime ExpiryDate { get; set; }
        public required bool IsClaimed { get; set; }
        public string UserID { get; set; }
    }
}
