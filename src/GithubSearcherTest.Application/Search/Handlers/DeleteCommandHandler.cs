using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Application.Search.Commands;
using GithubSearcherTest.Application.Search.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GithubSearcherTest.Application.Search.Handlers;

public class DeleteCommandHandler : IRequestHandler<DeleteCommand, DeleteCommandResponse>
{
    private readonly IAppDbContext _dbContext;

    public DeleteCommandHandler(IAppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<DeleteCommandResponse> Handle(
        DeleteCommand command,
        CancellationToken ct)
    {
        var searchResult = await _dbContext.SearchResults
            .FirstOrDefaultAsync(sr => sr.Id == command.Id);
        
        if (searchResult is not null)
        {
            _dbContext.SearchResults.Remove(searchResult);

            await _dbContext.SaveChangesAsync(ct);
        }

        return new DeleteCommandResponse
        {
            Succeeded = true
        };
    }
}
