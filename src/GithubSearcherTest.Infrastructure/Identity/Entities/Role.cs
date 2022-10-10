using Microsoft.AspNetCore.Identity;

namespace GithubSearcherTest.Infrastructure.Identity.Entities;

public class Role : IdentityRole<long>
{
    public Role(string roleName) : base(roleName)
    {
        
    }
}
