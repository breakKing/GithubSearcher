using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Infrastructure.Identity.Entities;
using GithubSearcherTest.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace GithubSearcherTest.Infrastructure.Identity;

public static class IdentityDependencyInjection
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;

            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.-_@";
            options.User.RequireUniqueEmail = false;

            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
        }).AddEntityFrameworkStores<AppDbContext>();

        services.AddTransient<IIdentityService, IdentityService>();

        return services;
    }
}
