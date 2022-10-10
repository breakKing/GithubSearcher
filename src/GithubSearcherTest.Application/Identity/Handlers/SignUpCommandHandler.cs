using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Application.Identity.Commands;
using GithubSearcherTest.Application.Identity.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Identity.Handlers;

public class SignUpCommandHandler : IRequestHandler<SignUpCommand, SignUpCommandResponse>
{
    private readonly IIdentityService _identityService;

    public SignUpCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<SignUpCommandResponse> Handle(SignUpCommand command, CancellationToken ct)
    {
        var result = await _identityService.SignUpAsync(command.Username, command.Password, ct);

        if (result.IsError)
        {
            return new SignUpCommandResponse
            {
                Succeeded = false,
                Errors = result.Errors
                    .ConvertAll(e => e.Description)
            };
        }

        return new SignUpCommandResponse
        {
            Succeeded = true,
            Errors = new List<string>(),
            User = result.Value
        };
    }
}
