using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsakSiteApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTechnologyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Technology",
                table: "Portfolio",
                newName: "Technologies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Technologies",
                table: "Portfolio",
                newName: "Technology");
        }
    }
}
