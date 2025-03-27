using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using pesona_migrate_registrasi;
using pesona_migrate_registrasi.Process;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Add services to the container.
        services.AddDbContext<MsDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("MsConnection"))
                    .EnableSensitiveDataLogging());
        services.AddDbContext<PgDbContext>(options =>
            options.UseNpgsql(context.Configuration.GetConnectionString("PgConnection"))
                    .EnableSensitiveDataLogging());

        // Add logging
        services.AddLogging(config =>
        {
            config.AddConsole();
            config.AddDebug();
        });
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    var refAplikasiProcess = services.GetRequiredService<RefAplikasiProcess>();
    await refAplikasiProcess.Process();
}

await host.RunAsync();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


