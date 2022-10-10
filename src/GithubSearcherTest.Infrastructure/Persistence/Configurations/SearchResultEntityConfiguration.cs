using GithubSearcherTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GithubSearcherTest.Infrastructure.Persistence.Configurations
{
    public class SearchResultEntityConfiguration : IEntityTypeConfiguration<SearchResult>
    {
        public void Configure(EntityTypeBuilder<SearchResult> builder)
        {
            builder.HasKey(s => s.Query);

            builder.Property(s => s.Query)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(s => s.Result)
                .HasColumnType("jsonb")
                .IsRequired();
        }
    }
}
