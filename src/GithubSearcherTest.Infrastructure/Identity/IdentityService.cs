using ErrorOr;
using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Application.Identity.Models;
using GithubSearcherTest.Infrastructure.Identity.Constants;
using GithubSearcherTest.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GithubSearcherTest.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public IdentityService(
        UserManager<User> userManager,
        RoleManager<Role> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public Task<ErrorOr<string>> GetAccessTokenAsync(
        string username,
        string password,
        CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<UserDto>> SignUpAsync(
        string username,
        string password,
        CancellationToken ct = default)
    {
        if (await _userManager.Users.AnyAsync(u => u.UserName == username))
        {
            return Error.Failure("IdentityService.UserAlreadyExists",
                "User with such a username already exists");
        }

        var user = new User
        {
            UserName = username
        };

        var result = await CreateUserAsync(user, password);
        
        if (!result.Succeeded)
        {
            return Error.Failure("IdentityService.FailedToCreateUser",
                string.Join('\n', result.Errors.Select(e => e.Description)));
        }

        return new UserDto
        {
            Id = user.Id,
            Username = username,
            Roles = (List<string>)await _userManager.GetRolesAsync(user)
        };
    }

    private async Task<IdentityResult> CreateUserAsync(
        User user,
        string password
    )
    {
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            return result;
        }

        result = await _userManager.AddToRoleAsync(user, RolesConstants.Common);
        if (!result.Succeeded)
        {
            await _userManager.DeleteAsync(user);
        }

        return result;
    }
}
