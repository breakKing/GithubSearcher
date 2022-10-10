using System.Collections.Generic;
using GithubSearcherTest.Application.Search.Models;

namespace GithubSearcherTest.Application.Search.Responses;

public class HistoryQueryResponse
{
    public long TotalCount { get; set; }
    public List<SearchResultDto> Results { get; set; } = new();
}
