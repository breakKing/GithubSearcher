namespace GithubSearcherTest.Web.Contracts;

public class FindRequest
{
    public string? QueryText { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
