namespace GithubSearcherTest.Application.Identity.Models;

public class UserDto
{
    public long Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new();
}
