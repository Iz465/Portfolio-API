using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsakSiteApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingPortfolioTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Portfolio",
                newName: "Technology");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Portfolio",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GithubLink",
                table: "Portfolio",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "GithubLink",
                table: "Portfolio");

            migrationBuilder.RenameColumn(
                name: "Technology",
                table: "Portfolio",
                newName: "Link");
        }
    }
}
