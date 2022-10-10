using System.Threading;
using System.Threading.Tasks;

namespace GithubSearcherTest.Application.Common.Abstractions
{
    public interface IGithubClient
    {
        Task<string> SearchForReposAsync(
            string queryText,
            int PageNumber = 1,
            int pageSize = 100,
            CancellationToken ct = default);
    }
}
