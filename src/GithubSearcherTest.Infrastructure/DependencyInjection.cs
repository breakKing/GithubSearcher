using GithubSearcherTest.Infrastructure.External;
using GithubSearcherTest.Infrastructure.Identity;
using GithubSearcherTest.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GithubSearcherTest.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        services.AddPersistenceServices(configuration, environment);

        services.AddExternalServices();

        services.AddIdentityServices();

        return services;
    }
}
