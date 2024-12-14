using Main_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Main_Application.Data
{
    public class MainApplicationDBContext : DbContext  
    {
        public MainApplicationDBContext(DbContextOptions<MainApplicationDBContext> options) : base(options){ }

        public DbSet<Feature> Features { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
