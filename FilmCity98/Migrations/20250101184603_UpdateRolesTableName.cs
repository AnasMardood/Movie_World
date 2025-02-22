using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmCity98.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRolesTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "security");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "security",
                newName: "Roles");
        }
    }
}
