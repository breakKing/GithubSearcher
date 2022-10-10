using GithubSearcherTest.Infrastructure.Identity;
using GithubSearcherTest.Infrastructure.Persistence.Seeds.Base;
using Microsoft.Extensions.Logging;
using OpenIddict.Abstractions;

namespace GithubSearcherTest.Infrastructure.Persistence.Seeds;

public class AppClientSeed : BaseClientDataSeed<AppClientSeed>
{
    private const string _clientId = "app-client";

    private static readonly OpenIddictApplicationDescriptor _postmanAppDesc = new()
    {
        ClientId = _clientId,
        ClientSecret = "app-client-secret",
        DisplayName = "Client for everyone",
        Permissions =
        {
            OpenIddictConstants.Permissions.Endpoints.Token,
            OpenIddictConstants.Permissions.GrantTypes.Password,

            OpenIddictConstants.Permissions.Prefixes.Scope + CustomIdentityConstants.GithubSearcherApiScope,
        }
    };

    public AppClientSeed(IOpenIddictApplicationManager manager,
        ILogger<AppClientSeed> logger)
        : base(_clientId, _postmanAppDesc, manager, logger)
    {

    }
}
