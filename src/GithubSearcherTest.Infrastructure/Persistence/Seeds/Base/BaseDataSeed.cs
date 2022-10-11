using GithubSearcherTest.Infrastructure.Persistence.Seeds.Interfaces;
using Microsoft.Extensions.Logging;

namespace GithubSearcherTest.Infrastructure.Persistence.Seeds.Base;

public abstract class BaseDataSeed<TSeed> : IDataSeed
{
    protected ILogger<TSeed> Logger { get; }

    protected BaseDataSeed(ILogger<TSeed> logger)
    {
        Logger = logger;
    }

    public async Task SeedAsync(CancellationToken ct = default)
    {
        try
        {
            await TrySeedAsync(ct);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "An error occurred during data seed of type {type}", typeof(TSeed));
            throw;
        }
    }

    protected abstract Task TrySeedAsync(CancellationToken ct = default);
}
