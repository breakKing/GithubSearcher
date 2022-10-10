using GithubSearcherTest.Application.Identity.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Identity.Commands;

public class AuthCommand : IRequest<AuthCommandResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }

    public AuthCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
