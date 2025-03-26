using Microsoft.EntityFrameworkCore;

namespace pesona_migrate_registrasi
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // public DbSet<Employee> Employees { get; set; }
        public DbSet<RefAplikasi> RefAplikasis { get; set; }
    }
}
