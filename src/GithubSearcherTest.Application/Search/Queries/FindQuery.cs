using GithubSearcherTest.Application.Search.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Search.Queries
{
    public class FindQuery: IRequest<FindQueryResponse>
    {
        public string QueryText { get; set; }

        public FindQuery(string queryText)
        {
            QueryText = queryText;
        }
    }
}
