using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Application.Search.Models;
using GithubSearcherTest.Application.Search.Queries;
using GithubSearcherTest.Application.Search.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GithubSearcherTest.Application.Search.Handlers;

public class HistoryQueryHandler : IRequestHandler<HistoryQuery, HistoryQueryResponse>
{
    private const int PAGE_SIZE_LIMIT = 50;
    private readonly IAppDbContext _dbContext;

    public HistoryQueryHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<HistoryQueryResponse> Handle(HistoryQuery query, CancellationToken ct)
    {
        var pageNumber = query.PageNumber;
        var pageSize = query.PageSize > PAGE_SIZE_LIMIT ? PAGE_SIZE_LIMIT : query.PageSize;
        var pagesToSkip = (pageNumber - 1) * pageSize;

        var results = await _dbContext.SearchResults
            .OrderBy(r => r.Id)
            .Skip(pagesToSkip)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(ct);

        var totalCount = await _dbContext.SearchResults
            .LongCountAsync(ct);

        return new HistoryQueryResponse
        {
            TotalCount = totalCount,
            Results = results.ConvertAll(r => 
            {
                var data = JsonConvert.DeserializeObject<SearchResultDto>(r.Result);
                data.id = r.Id;

                return data;
            })
        };
    }
}
