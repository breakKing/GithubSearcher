using GithubSearcherTest.Application.Search.Queries;
using GithubSearcherTest.Application.Search.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GithubSearcherTest.Application.Search.Handlers
{
    public class LocalSearchQueryHandler : IRequestHandler<LocalSearchQuery, LocalSearchQueryResponse>
    {
        public async Task<LocalSearchQueryResponse> Handle(LocalSearchQuery request, CancellationToken ct)
        {
            throw new System.NotImplementedException();
        }
    }
}
