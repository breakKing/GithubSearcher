namespace GithubSearcherTest.Application.Identity.Models;

public class UserDto
{
    public long Id { get; set; }
    public string Username { get; set; }
    public List<string> Roles { get; set; }
}
