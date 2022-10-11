using GithubSearcherTest.Application.Identity.Models;

namespace GithubSearcherTest.Application.Identity.Responses;

public class AuthCommandResponse
{
    public bool Succeeded { get; set; }
    public UserDto? User { get; set; }
}
