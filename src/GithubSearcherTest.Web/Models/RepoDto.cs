namespace GithubSearcherTest.Web.Models;

public class RepoDto
{
    public string full_name { get; set; }
    public long stargazers_count { get; set; }
    public long watchers_count { get; set; }
    public string html_url { get; set; }
}
