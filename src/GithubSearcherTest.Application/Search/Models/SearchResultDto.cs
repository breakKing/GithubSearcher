using Newtonsoft.Json;

namespace GithubSearcherTest.Application.Search.Models;

public class SearchResultDto
{
    [JsonIgnore]
    public long id { get; set; }
    public long total_count { get; set; }
    public List<RepoDto> items { get; set; } = new();
}
