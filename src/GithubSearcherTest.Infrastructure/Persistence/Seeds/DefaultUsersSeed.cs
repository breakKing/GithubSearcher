using GithubSearcherTest.Infrastructure.Identity.Constants;
using GithubSearcherTest.Infrastructure.Identity.Entities;
using GithubSearcherTest.Infrastructure.Persistence.Seeds.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace GithubSearcherTest.Infrastructure.Persistence.Seeds;

public class DefaultUsersSeed : BaseDataSeed<DefaultUsersSeed>
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    private const string _username = "test_user";
    private const string _password = "Test_User_Pass_123";

    public DefaultUsersSeed(UserManager<User> userManager,
        RoleManager<Role> roleManager,
        ILogger<DefaultUsersSeed> logger)
        : base(logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    protected override async Task TrySeedAsync(CancellationToken ct = default)
    {
        var role = await GetOrCreateRoleAsync(ct);
        var user = await GetOrCreateUserAsync(ct);
        await AddUserToRoleIfNeeded(user, role, ct);
    }

    private async Task<Role> GetOrCreateRoleAsync(CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();

        var role = await _roleManager.FindByNameAsync(RolesConstants.Common);
        if (role is null)
        {
            role = new Role(RolesConstants.Common);
            await _roleManager.CreateAsync(role);
        }

        return role;
    }

    private async Task<User> GetOrCreateUserAsync(CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();

        var user = await _userManager.FindByNameAsync(_username);
        if (user is null)
        {
            user = new User
            {
                UserName = _username,
            };
            await _userManager.CreateAsync(user, _password);
        }

        return user;
    }

    private async Task AddUserToRoleIfNeeded(
        User user,
        Role role,
        CancellationToken ct = default)
    {
        ct.ThrowIfCancellationRequested();

        var userHasRole = await _userManager.IsInRoleAsync(user, role.Name);
        if (!userHasRole)
        {
            await _userManager.AddToRoleAsync(user, role.Name);
        }
    }
}
