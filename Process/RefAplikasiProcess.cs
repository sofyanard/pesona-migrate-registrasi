using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace pesona_migrate_registrasi.Process
{
    internal class RefAplikasiProcess
    {
        private readonly MsDbContext _msDbContext;
        private readonly PgDbContext _pgDbContext;
        private readonly ILogger<RefAplikasiProcess> _logger;

        public RefAplikasiProcess(MsDbContext msDbContext, PgDbContext pgDbContext, ILogger<RefAplikasiProcess> logger)
        {
            _msDbContext = msDbContext;
            _pgDbContext = pgDbContext;
            _logger = logger;
        }

        /*
        public async Task MigrateRefAplikasi()
        {
            var refAplikasiMs = await _msDbContext.RefAplikasiMss.ToListAsync();
            var refAplikasiPg = refAplikasiMs.Select(x => new RefAplikasiPg
            {
                Id = x.Id,
                Kode = x.Kode,
                Nama = x.Nama,
                Deskripsi = x.Deskripsi,
                Status = x.Status,
                CreatedBy = x.CreatedBy,
                CreatedDate = x.CreatedDate,
                UpdatedBy = x.UpdatedBy,
                UpdatedDate = x.UpdatedDate
            }).ToList();
            await _pgDbContext.RefAplikasiPgs.AddRangeAsync(refAplikasiPg);
            await _pgDbContext.SaveChangesAsync();
        }
        */

        public async Task Process()
        {
            try
            {
                // Perform database operations
                var refAplikasiMss = _msDbContext.RefAplikasiMss.ToList();
                foreach (var refAplikasiMs in refAplikasiMss)
                {
                    _logger.LogInformation($"RefAplikasi Id: {refAplikasiMs.KdApp}, Name: {refAplikasiMs.NmApp}");
                }
                var refAplikasiPgs = _pgDbContext.RefAplikasiPgs.ToList();
                foreach (var refAplikasiPg in refAplikasiPgs)
                {
                    _logger.LogInformation($"RefAplikasi Id: {refAplikasiPg.KdApp}, Name: {refAplikasiPg.NmApp}");
                }

                _logger.LogInformation("Database operations performed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while performing database operations.");
            }
        }
    }
}
