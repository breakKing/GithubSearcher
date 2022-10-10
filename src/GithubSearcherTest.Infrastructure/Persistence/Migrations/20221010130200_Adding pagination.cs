using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GithubSearcherTest.Infrastructure.Persistence.Migrations
{
    public partial class Addingpagination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchResult",
                table: "SearchResult");

            migrationBuilder.RenameTable(
                name: "SearchResult",
                newName: "SearchResults");

            migrationBuilder.RenameIndex(
                name: "IX_SearchResult_Query",
                table: "SearchResults",
                newName: "IX_SearchResults_Query");

            migrationBuilder.AddColumn<int>(
                name: "PageNumber",
                table: "SearchResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PageSize",
                table: "SearchResults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchResults",
                table: "SearchResults",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SearchResults",
                table: "SearchResults");

            migrationBuilder.DropColumn(
                name: "PageNumber",
                table: "SearchResults");

            migrationBuilder.DropColumn(
                name: "PageSize",
                table: "SearchResults");

            migrationBuilder.RenameTable(
                name: "SearchResults",
                newName: "SearchResult");

            migrationBuilder.RenameIndex(
                name: "IX_SearchResults_Query",
                table: "SearchResult",
                newName: "IX_SearchResult_Query");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SearchResult",
                table: "SearchResult",
                column: "Id");
        }
    }
}
