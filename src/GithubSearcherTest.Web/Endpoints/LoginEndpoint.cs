using FastEndpoints.Security;
using GithubSearcherTest.Application.Identity.Commands;
using GithubSearcherTest.Web.Contracts;
using MediatR;

namespace GithubSearcherTest.Web.Endpoints;

public class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    private readonly IMediator _mediator;

    public LoginEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("api/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var command = new AuthCommand(req.Username!, req.Password!);
        var commandResponse = await _mediator.Send(command, ct);
        
        if (commandResponse.Succeeded)
        {
            var user = commandResponse.User!;

            var jwtToken = JWTBearer.CreateToken(
                signingKey: "SuperSecretTokenSigningKey",
                issuer: "GithubSearcherIssuer",
                audience: "GithubSearcherAudience",
                expireAt: DateTime.UtcNow.AddDays(1),
                claims: new[] { ("Username", user.Username), ("Id", user.Id.ToString()) },
                roles: user.Roles.ToArray());

            await SendAsync(new LoginResponse
            {
                Succeeded = true,
                AccessToken = jwtToken
            }, cancellation: ct);

            return;
        }
        
        await SendAsync(new LoginResponse
        {
            Succeeded = false
        }, cancellation: ct);
    }
}
