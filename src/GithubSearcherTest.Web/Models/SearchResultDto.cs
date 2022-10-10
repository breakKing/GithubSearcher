using System.Collections.Generic;

namespace GithubSearcherTest.Web.Models;

public class SearchResultDto
{
    public long total_count { get; set; }
    public List<RepoDto> items { get; set; } = new();
}
