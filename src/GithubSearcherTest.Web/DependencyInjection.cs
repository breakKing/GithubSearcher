using FastEndpoints.Security;

namespace GithubSearcherTest.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddFastEndpoints();
        services.AddAuthenticationJWTBearer(
            "SuperSecretTokenSigningKey",
            "GithubSearcherIssuer",
            "GithubSearcherAudience"
        );
        
        return services;
    }
}
