using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GithubSearcherTest.Infrastructure.Persistence.Migrations
{
    public partial class Initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchResult",
                columns: table => new
                {
                    Query = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Result = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchResult", x => x.Query);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchResult");
        }
    }
}
