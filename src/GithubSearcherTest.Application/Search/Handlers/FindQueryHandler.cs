using System.Threading;
using System.Threading.Tasks;
using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Application.Search.Models;
using GithubSearcherTest.Application.Search.Queries;
using GithubSearcherTest.Application.Search.Responses;
using GithubSearcherTest.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GithubSearcherTest.Application.Search.Handlers
{
    public class FindQueryHandler : IRequestHandler<FindQuery, FindQueryResponse>
    {
        private readonly IGithubClient _client;
        private readonly IAppDbContext _dbContext;

        public FindQueryHandler(
            IGithubClient client,
            IAppDbContext dbContext)
        {
            _client = client;
            _dbContext = dbContext;
        }

        public async Task<FindQueryResponse> Handle(
            FindQuery query,
            CancellationToken ct)
        {
            var dbCache = await _dbContext.SearchResults.FirstOrDefaultAsync(sr => sr.Query == query.QueryText
                && sr.PageNumber == query.PageNumber
                && sr.PageSize == query.PageSize, ct);

            if (dbCache is not null)
            {
                var cachedData = JsonConvert.DeserializeObject<SearchResultDto>(dbCache.Result);
                cachedData.id = dbCache.Id;
                return new FindQueryResponse
                {
                    Result = cachedData
                };
            }

            var result = await _client.SearchForReposAsync(
                query.QueryText,
                query.PageNumber,
                query.PageSize,
                ct);

            var data = JsonConvert.DeserializeObject<SearchResultDto>(result);
            var optimizedJson = JsonConvert.SerializeObject(data);

            var searchResult = new SearchResult
            {
                Query = query.QueryText,
                Result = optimizedJson,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
            _dbContext.SearchResults.Add(searchResult);

            await _dbContext.SaveChangesAsync(ct);

            data.id = searchResult.Id;

            return new FindQueryResponse
            {
                Result = data
            };
        }
    }
}
