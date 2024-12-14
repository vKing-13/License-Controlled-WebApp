using License_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace License_Server.Data
{
    public class LicenseSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LicenseServerDBContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LicenseServerDBContext>>()))
            {
                if (context.Licenses.Any())
                {
                    return;   
                }
                context.Licenses.AddRange(
                    new License
                    {
                        Id = Guid.NewGuid(),
                        LicenseKey = "STANDARD-123456",
                        LicenseLevel = LicenseLevel.standard,
                        ExpiryDate = DateTime.UtcNow.AddYears(2), 
                        IsClaimed = false,
                        UserID = null
                    },
                    new License
                    {
                        Id = Guid.NewGuid(),
                        LicenseKey = "PREMIUM-654321",
                        LicenseLevel = LicenseLevel.premium,
                        ExpiryDate = DateTime.UtcNow.AddYears(3),
                        IsClaimed = false,
                        UserID = null
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
