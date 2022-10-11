namespace GithubSearcherTest.Infrastructure.Persistence.Seeds.Interfaces;

public interface IDataSeed
{
    Task SeedAsync(CancellationToken ct = default);
}
