using GithubSearcherTest.Application.Identity.Commands;
using GithubSearcherTest.Web.Contracts;
using GithubSearcherTest.Web.Services;
using MediatR;

namespace GithubSearcherTest.Web.Endpoints;

public class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    private readonly IMediator _mediator;
    private readonly IJWTService _jwtService;

    public LoginEndpoint(IMediator mediator, IJWTService jwtService)
    {
        _mediator = mediator;
        _jwtService = jwtService;
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

            var jwtToken = _jwtService.CreateToken(user);

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
