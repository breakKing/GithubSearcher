using GithubSearcherTest.Application.Search.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Search.Queries
{
    public class FindQuery: IRequest<FindQueryResponse>
    {
        public string QueryText { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public FindQuery(string queryText, int pageSize, int pageNumber)
        {
            QueryText = queryText;
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
    }
}
