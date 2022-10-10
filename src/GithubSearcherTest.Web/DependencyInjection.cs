using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;

namespace GithubSearcherTest.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddFastEndpoints();
        
        return services;
    }
}
