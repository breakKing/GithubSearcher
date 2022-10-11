using FastEndpoints.Security;
using GithubSearcherTest.Application.Identity.Models;
using GithubSearcherTest.Web.Options;
using Microsoft.Extensions.Options;

namespace GithubSearcherTest.Web.Services;

public interface IJWTService
{
    string CreateToken(UserDto user);
}

public class JWTService : IJWTService
{
    private readonly IOptions<JWTOptions> _jwtOptions;

    public JWTService(IOptions<JWTOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions;
    }

    public string CreateToken(UserDto user)
    {
        return JWTBearer.CreateToken(
                signingKey: _jwtOptions.Value.SigningKey,
                issuer: _jwtOptions.Value.Issuer,
                audience: _jwtOptions.Value.Audience,
                expireAt: DateTime.UtcNow.AddMinutes(_jwtOptions.Value.DurationMinutes),
                claims: new[] { ("Username", user.Username), ("Id", user.Id.ToString()) },
                roles: user.Roles.ToArray());
    }
}
