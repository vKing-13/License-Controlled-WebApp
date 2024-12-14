using License_Server.Models;
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
    
}
