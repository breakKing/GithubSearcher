using GithubSearcherTest.Application.Search.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Search.Queries
{
    public class RemoteSearchQuery: IRequest<RemoteSearchQueryResponse>
    {
        public string QueryText { get; set; }

        public RemoteSearchQuery(string queryText)
        {
            QueryText = queryText;
        }
    }
}
