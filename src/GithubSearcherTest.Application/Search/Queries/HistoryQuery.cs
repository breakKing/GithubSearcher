using GithubSearcherTest.Application.Search.Responses;
using MediatR;

namespace GithubSearcherTest.Application.Search.Queries;

public class HistoryQuery : IRequest<HistoryQueryResponse>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public HistoryQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
