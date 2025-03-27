using Microsoft.EntityFrameworkCore;
using pesona_migrate_registrasi.ModelMs;

namespace pesona_migrate_registrasi
{
    internal class MsDbContext : DbContext
    {
        public MsDbContext(DbContextOptions<MsDbContext> options)
            : base(options)
        {
        }

        public DbSet<RefAplikasiMs> RefAplikasiMss { get; set; }
    }
}
