using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using pesona_migrate_registrasi;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Add services to the container.
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DefaultConnection")));

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

    try
    {
        // Use the DbContext here
        var dbContext = services.GetRequiredService<ApplicationDbContext>();

        // Perform database operations
        var employees = dbContext.Employees.ToList();
        foreach (var employee in employees)
        {
            logger.LogInformation($"Employee Id: {employee.EmployeeId}, Name: {employee.EmployeeName}");
        }

        logger.LogInformation("Database operations performed successfully.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while performing database operations.");
    }
}

await host.RunAsync();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


