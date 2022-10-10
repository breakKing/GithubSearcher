using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Domain.Entities;
using GithubSearcherTest.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GithubSearcherTest.Infrastructure.Persistence
{
    public class AppDbContext : IdentityDbContext<User, Role, long>, IAppDbContext
    {
        public DbSet<SearchResult> SearchResults => Set<SearchResult>();

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
