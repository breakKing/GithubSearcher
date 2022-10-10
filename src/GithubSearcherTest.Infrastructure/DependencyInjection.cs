using GithubSearcherTest.Infrastructure.External;
using GithubSearcherTest.Infrastructure.Identity;
using GithubSearcherTest.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GithubSearcherTest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        services.AddPersistenceServices(configuration, environment);

        services.AddExternalServices();

        services.AddIdentityServices();

        return services;
    }
}
