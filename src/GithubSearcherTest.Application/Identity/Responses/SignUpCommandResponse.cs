using GithubSearcherTest.Application.Identity.Models;

namespace GithubSearcherTest.Application.Identity.Responses;

public class SignUpCommandResponse
{
    public bool Succeeded { get; set; }
    public List<string> Errors { get; set; } = new();
    public UserDto? User { get; set; }
}
