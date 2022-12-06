using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeTeamBuilder.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class AddingImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sprite",
                table: "PokemonTeamMembers",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sprite",
                table: "PokemonTeamMembers");
        }
    }
}
