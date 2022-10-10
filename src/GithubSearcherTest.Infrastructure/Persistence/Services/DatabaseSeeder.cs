using System;
using System.Threading;
using System.Threading.Tasks;
using GithubSearcherTest.Infrastructure.Persistence.Seeds.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GithubSearcherTest.Infrastructure.Persistence.Services;

public class DatabaseSeeder : IHostedService
{
    private readonly IServiceScopeFactory _factory;

    public DatabaseSeeder(IServiceScopeFactory factory)
    {
        _factory = factory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _factory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<DatabaseSeeder>>();
        var seeds = scope.ServiceProvider.GetServices<IDataSeed>();

        try
        {
            if (context.Database.IsNpgsql())
            {
                await context.Database.MigrateAsync(cancellationToken);
            }

            foreach (var seed in seeds)
            {
                await seed.SeedAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initializing the database before seeding");
            throw;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
