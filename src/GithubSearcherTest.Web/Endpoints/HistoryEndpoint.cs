using System.Threading;
using System.Threading.Tasks;
using GithubSearcherTest.Application.Search.Queries;
using GithubSearcherTest.Web.Contracts;
using MediatR;

namespace GithubSearcherTest.Web.Endpoints;

public class HistoryEndpoint : Endpoint<HistoryRequest, HistoryResponse>
{
    private readonly IMediator _mediator;

    public HistoryEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("api/find");
        AllowAnonymous();
    }

    public override async Task HandleAsync(HistoryRequest req, CancellationToken ct)
    {
        var query = new HistoryQuery(req.PageNumber, req.PageSize);
        var queryResponse = await _mediator.Send(query, ct);

        var response = new HistoryResponse()
        {
            TotalCount = queryResponse.TotalCount,
            Results = queryResponse.Results
        };
        await SendAsync(response, cancellation: ct);
    }
}
