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

        public async Task<FindQueryResponse> Handle(FindQuery query, CancellationToken ct)
        {
            var result = await _client.SearchForReposAsync(
                query.QueryText,
                query.PageNumber,
                query.PageSize,
                ct);

            return new FindQueryResponse(result);
        }
    }
}
