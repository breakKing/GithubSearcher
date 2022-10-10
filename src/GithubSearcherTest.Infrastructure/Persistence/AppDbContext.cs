using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GithubSearcherTest.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
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
