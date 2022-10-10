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

    public async Task<string> SearchForReposAsync(
        string queryText,
        int pageNumber = 1,
        int pageSize = 100,
        CancellationToken ct = default)
    {
        var client = _factory.CreateClient("Github");

        var response = await client.GetAsync($"/search/repositories?q={queryText}&per_page={pageSize}&page={pageNumber}", ct);

        return await response.Content.ReadAsStringAsync(ct);
    }
}
