using ContractsAppProg.Models;
using Microsoft.EntityFrameworkCore;

namespace ContractsAppProg.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; } // Add Claims DbSet
    }
}
