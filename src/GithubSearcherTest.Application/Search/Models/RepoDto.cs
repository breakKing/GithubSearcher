namespace GithubSearcherTest.Application.Search.Models;

public class RepoDto
{
    public string full_name { get; set; } = string.Empty;
    public long stargazers_count { get; set; }
    public long watchers_count { get; set; }
    public string html_url { get; set; } = string.Empty;
}
