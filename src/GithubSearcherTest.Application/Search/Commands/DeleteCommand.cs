using GithubSearcherTest.Application.Search.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Search.Commands;

public class DeleteCommand : IRequest<DeleteCommandResponse>
{
    public long Id { get; set; }

    public DeleteCommand(long id)
    {
        Id = id;
    }
}
