using System.Threading;
using System.Threading.Tasks;

namespace GithubSearcherTest.Infrastructure.Persistence.Seeds.Interfaces;

public interface IDataSeed
{
    Task SeedAsync(CancellationToken ct = default);
}
