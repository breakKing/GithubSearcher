using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Infrastructure.Persistence.Seeds;
using GithubSearcherTest.Infrastructure.Persistence.Seeds.Interfaces;
using GithubSearcherTest.Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GithubSearcherTest.Infrastructure.Persistence;

public static class PersistenceDependencyInjection
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        services.AddDbContext<AppDbContext>(o =>
        {
            o.UseNpgsql(configuration.GetConnectionString("Database"));
            o.UseOpenIddict<long>();
        });

        services.AddScoped<IAppDbContext, AppDbContext>();
        
        services.AddDataSeeds(environment);
        
        return services;
    }

    private static IServiceCollection AddDataSeeds(this IServiceCollection services, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            services.AddScoped<IDataSeed, DefaultUsersSeed>();
            services.AddScoped<IDataSeed, AppClientSeed>();

            services.AddHostedService<DatabaseSeeder>();
        }

        return services;
    }
}
