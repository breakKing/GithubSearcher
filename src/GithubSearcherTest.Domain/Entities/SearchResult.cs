namespace GithubSearcherTest.Domain.Entities;

public class SearchResult
{
    public long Id { get; set; }
    public string Query { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
