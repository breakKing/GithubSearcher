using GithubSearcherTest.Application.Search.Commands;
using GithubSearcherTest.Web.Contracts;
using MediatR;

namespace GithubSearcherTest.Web.Endpoints;

public class DeleteEndpoint : Endpoint<DeleteRequest, DeleteResponse>
{
    private readonly IMediator _mediator;

    public DeleteEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Delete("api/find/{Id}");
        Roles("Common");
    }

    public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
    {
        var command = new DeleteCommand(req.Id);
        var commandResponse = await _mediator.Send(command, ct);

        var response = new DeleteResponse()
        {
            Succeeded = commandResponse.Succeeded
        };
        await SendAsync(response, cancellation: ct);
    }
}
