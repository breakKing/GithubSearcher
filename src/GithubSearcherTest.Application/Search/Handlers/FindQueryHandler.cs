using System.Threading;
using System.Threading.Tasks;
using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Application.Search.Queries;
using GithubSearcherTest.Application.Search.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Search.Handlers
{
    public class FindQueryHandler : IRequestHandler<FindQuery, FindQueryResponse>
    {
        private readonly IGithubClient _client;

        public FindQueryHandler(IGithubClient client)
        {
            _client = client;
        }

        public async Task<FindQueryResponse> Handle(FindQuery request, CancellationToken ct)
        {
            var queryText = request.QueryText;

            var result = await _client.SearchForReposAsync(queryText, ct);

            return new FindQueryResponse(result);
        }
    }
}
