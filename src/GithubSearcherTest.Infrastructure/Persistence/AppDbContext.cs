using GithubSearcherTest.Application.Common.Abstractions;
using GithubSearcherTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace GithubSearcherTest.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public IQueryable SearchResults => Set<SearchResult>();

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
