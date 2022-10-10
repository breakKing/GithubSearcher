using GithubSearcherTest.Application.Identity.Models;

namespace GithubSearcherTest.Web.Contracts;

public class SignUpResponse
{
    public bool Succeeded { get; set; }
    public List<string> Errors { get; set; }
    public UserDto User { get; set; }
}
