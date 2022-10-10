namespace GithubSearcherTest.Web.Contracts;

public class LoginResponse
{
    public bool Succeeded { get; set; }
    public List<string> Errors { get; set; }
    public string AccessToken { get; set; }
}
