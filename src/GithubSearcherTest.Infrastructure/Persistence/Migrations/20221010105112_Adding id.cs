using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GithubSearcherTest.Infrastructure.Persistence.Migrations
{
    public partial class Addingid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchResult",
                table: "SearchResult");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "SearchResult",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchResult",
                table: "SearchResult",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SearchResult_Query",
                table: "SearchResult",
                column: "Query");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchResult",
                table: "SearchResult");

            migrationBuilder.DropIndex(
                name: "IX_SearchResult_Query",
                table: "SearchResult");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SearchResult");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchResult",
                table: "SearchResult",
                column: "Query");
        }
    }
}
