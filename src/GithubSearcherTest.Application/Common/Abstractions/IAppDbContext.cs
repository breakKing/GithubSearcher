using System.Linq;

namespace GithubSearcherTest.Application.Common.Abstractions
{
    public interface IAppDbContext
    {
        IQueryable SearchResults { get;  }
    }
}
