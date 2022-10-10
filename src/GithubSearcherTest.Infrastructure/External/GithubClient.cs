using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GithubSearcherTest.Application.Common.Abstractions;

namespace GithubSearcherTest.Infrastructure.External;

public class GithubClient : IGithubClient
{
    private readonly IHttpClientFactory _factory;

    public GithubClient(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<string> SearchForReposAsync(string queryText, CancellationToken ct = default)
    {
        var client = _factory.CreateClient("Github");
        return string.Empty;
    }
}
