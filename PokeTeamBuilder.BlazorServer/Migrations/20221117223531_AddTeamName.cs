using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeTeamBuilder.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Teams",
                newName: "TeamName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeamName",
                table: "Teams",
                newName: "Url");
        }
    }
}
