using System.Collections.Generic;
using GithubSearcherTest.Application.Search.Models;

namespace GithubSearcherTest.Web.Contracts;

public class HistoryResponse
{
    public long TotalCount { get; set; }
    public List<SearchResultDto> Results { get; set; } = new();
}
