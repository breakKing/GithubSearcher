using ErrorOr;
using GithubSearcherTest.Application.Identity.Models;

namespace GithubSearcherTest.Application.Common.Abstractions;

public interface IIdentityService
{
    Task<ErrorOr<UserDto>> SignUpAsync(
        string username,
        string password,
        CancellationToken ct = default
    );

    Task<UserDto?> AuthAsync(
        string username,
        string password,
        CancellationToken ct = default
    );
}
