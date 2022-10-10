using GithubSearcherTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GithubSearcherTest.Infrastructure.Persistence.Configurations
{
    public class SearchResultEntityConfiguration : IEntityTypeConfiguration<SearchResult>
    {
        public void Configure(EntityTypeBuilder<SearchResult> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .UseIdentityByDefaultColumn();

            builder.Property(s => s.Query)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(s => s.Result)
                .HasColumnType("jsonb")
                .IsRequired();

            builder.HasIndex(s => s.Query);
        }
    }
}
