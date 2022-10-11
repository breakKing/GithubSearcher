using FastEndpoints.Security;
using GithubSearcherTest.Web.Options;
using GithubSearcherTest.Web.Services;

namespace GithubSearcherTest.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddRazorPages();
        services.AddFastEndpoints();

        services.Configure<JWTOptions>(
            configuration.GetSection(JWTOptions.SectionName));

        var jwtOptions = new JWTOptions();
        configuration.GetSection(JWTOptions.SectionName).Bind(jwtOptions);
        
        services.AddAuthenticationJWTBearer(
            jwtOptions.SigningKey,
            jwtOptions.Issuer,
            jwtOptions.Audience
        );
        
        services.AddSingleton<IJWTService, JWTService>();
        
        return services;
    }
}
