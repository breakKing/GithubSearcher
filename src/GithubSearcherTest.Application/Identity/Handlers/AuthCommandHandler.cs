using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Application.Identity.Commands;
using GithubSearcherTest.Application.Identity.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Identity.Handlers;

public class AuthCommandHandler : IRequestHandler<AuthCommand, AuthCommandResponse>
{
    private readonly IIdentityService _identityService;

    public AuthCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<AuthCommandResponse> Handle(
        AuthCommand command,
        CancellationToken ct)
    {
        var user = await _identityService.AuthAsync(
            command.Username,
            command.Password,
            ct);

        if (user is null)
        {
            return new AuthCommandResponse
            {
                Succeeded = false
            };
        }

        return new AuthCommandResponse
        {
            Succeeded = true,
            User = user
        };
    }
}
