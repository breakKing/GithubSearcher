using System.Threading;
using System.Threading.Tasks;
using GithubSearcherTest.Application.Search.Queries;
using GithubSearcherTest.Application.Search.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Search.Handlers
{
    public class RemoteSearchQueryHandler : IRequestHandler<RemoteSearchQuery, RemoteSearchQueryResponse>
    {
        public async Task<RemoteSearchQueryResponse> Handle(RemoteSearchQuery request, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }
    }
}
