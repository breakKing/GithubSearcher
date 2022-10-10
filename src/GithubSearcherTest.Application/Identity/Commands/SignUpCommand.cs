using GithubSearcherTest.Application.Identity.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Identity.Commands;

public class SignUpCommand : IRequest<SignUpCommandResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }

    public SignUpCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
