using Microsoft.EntityFrameworkCore;

namespace ContractsAppProg.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<CustomClaim> Claims { get; set; }
    }
}
