using System.Collections.Generic;
using GithubSearcherTest.Application.Search.Models;

namespace GithubSearcherTest.Application.Search.Responses;

public class FindQueryResponse
{
    public SearchResultDto Result { get; set; } = new();
}
