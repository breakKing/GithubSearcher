namespace GithubSearcherTest.Domain.Entities
{
    public class SearchResult
    {
        public long Id { get; set; }
        public string Query { get; set; }
        public string Result { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
