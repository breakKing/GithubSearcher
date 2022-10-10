using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OpenIddict.Abstractions;

namespace GithubSearcherTest.Infrastructure.Persistence.Seeds.Base;

public abstract class BaseClientDataSeed<TSeed> : BaseDataSeed<TSeed>
{
    protected string ClientId { get; }
    protected OpenIddictApplicationDescriptor AppDesc { get; }

    protected IOpenIddictApplicationManager Manager { get; }

    protected BaseClientDataSeed(string clientId,
        OpenIddictApplicationDescriptor appDesc,
        IOpenIddictApplicationManager manager,
        ILogger<TSeed> logger) : base(logger)
    {
        ClientId = clientId;
        AppDesc = appDesc;

        Manager = manager;
    }

    protected override async Task TrySeedAsync(CancellationToken ct = default)
    {
        if (await Manager.FindByClientIdAsync(ClientId, ct) is null)
        {
            await Manager.CreateAsync(AppDesc, ct);
        }
    }
}
