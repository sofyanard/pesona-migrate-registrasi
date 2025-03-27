using Microsoft.EntityFrameworkCore;
using pesona_migrate_registrasi.ModelMs;
using pesona_migrate_registrasi.ModelPg;

namespace pesona_migrate_registrasi
{
    internal class PgDbContext : DbContext
    {
        public PgDbContext(DbContextOptions<PgDbContext> options)
            : base(options)
        {
        }

        public DbSet<RefAplikasiPg> RefAplikasiPgs { get; set; }
    }
}
