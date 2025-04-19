using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace RO.DevTest.Persistence.Extension;

public static class MigrationExtension
{
    public async static Task RunMigration(this IServiceProvider service)
    {
        using (var scope = service.CreateScope())
        {
            var services = scope.ServiceProvider;
            var maxRetryAttempts = 2;
            var delayBetweenRetries = TimeSpan.FromSeconds(2);
            for (var attempt = 0; attempt < maxRetryAttempts; attempt++)
            {
                try
                {
                    var dbContext = services.GetRequiredService<DefaultContext>();
                    var pedingMigrations = dbContext.Database.GetPendingMigrations();
                    if (pedingMigrations.Any())
                    {
                        Console.WriteLine("Have peding migrations: Apply migrations...");
                        dbContext.Database.Migrate();
                    }

                    Console.WriteLine("Dont have any pending migrations...");
                    break;
                }
                catch (PostgresException e)
                {
                    if (e.SqlState == "42P07")
                    {
                        Console.WriteLine("Error: This migration already exist, Aborting migration.");
                        break;
                    }

                    Console.WriteLine($"Error when try to verify/apply migration (try  {attempt + 1}):  {e.Message}");
                    if (attempt < maxRetryAttempts - 1)
                    {
                        Console.WriteLine($"Waiting.. {delayBetweenRetries / 1000} Seconds before to try again...");
                        await Task.Delay(delayBetweenRetries);
                    }
                }
            }
        }
    }
}