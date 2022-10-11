using GithubSearcherTest.Application.Identity.Commands;
using GithubSearcherTest.Web.Contracts;
using MediatR;

namespace GithubSearcherTest.Web.Endpoints;

public class SignUpEndpoint : Endpoint<SignUpRequest, SignUpResponse>
{
    private readonly IMediator _mediator;

    public SignUpEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("api/sign-up");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SignUpRequest req, CancellationToken ct)
    {
        var command = new SignUpCommand(req.Username!, req.Password!);
        var commandResponse = await _mediator.Send(command, ct);

        var response = new SignUpResponse()
        {
            Succeeded = commandResponse.Succeeded,
            Errors = commandResponse.Errors,
            User = commandResponse.User
        };
        await SendAsync(response, cancellation: ct);
    }
}
