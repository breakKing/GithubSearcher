using System.Threading;
using System.Threading.Tasks;

namespace GithubSearcherTest.Application.Common.Abstractions
{
    public interface IGithubClient
    {
        Task<string> SearchForReposAsync(string queryText, CancellationToken ct = default);
    }
}
