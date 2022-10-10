using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GithubSearcherTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GithubSearcherTest.Application.Common.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<SearchResult> SearchResults { get;  }

        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
