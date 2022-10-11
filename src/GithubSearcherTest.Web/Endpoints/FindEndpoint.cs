using GithubSearcherTest.Application.Search.Queries;
using GithubSearcherTest.Web.Contracts;
using MediatR;

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
        Roles("Common");
    }

    public override async Task HandleAsync(FindRequest req, CancellationToken ct)
    {
        var query = new FindQuery(req.QueryText!, req.PageSize, req.PageNumber);
        var queryResponse = await _mediator.Send(query, ct);

        var response = new FindResponse()
        {
            Result = queryResponse.Result
        };
        await SendAsync(response, cancellation: ct);
    }
}
