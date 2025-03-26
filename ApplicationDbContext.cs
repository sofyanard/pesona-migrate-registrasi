using Microsoft.EntityFrameworkCore;

namespace pesona_migrate_registrasi
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your DbSets here. For example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
