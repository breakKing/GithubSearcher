using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using GithubSearcherTest.Application.Search.Queries;
using GithubSearcherTest.Web.Contracts;
using GithubSearcherTest.Web.Models;
using MediatR;
using Newtonsoft.Json;

namespace GithubSearcherTest.Web.Endpoints;

public class FindEndpoint : Endpoint<FindRequest, FindResponse>
{
    private readonly IMediator _mediator;

    public FindEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("api/find");
        AllowAnonymous();
    }

    public override async Task HandleAsync(FindRequest req, CancellationToken ct)
    {
        var query = new FindQuery(req.QueryText);
        var result = await _mediator.Send(query, ct);

        var data = JsonConvert.DeserializeObject<SearchResultDto>(result.JsonResult);

        var response = new FindResponse()
        {
            Result = data
        };
        await SendAsync(response, cancellation: ct);
    }
}
