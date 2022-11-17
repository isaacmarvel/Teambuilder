using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeTeamBuilder.BlazorServer.Migrations
{
    /// <inheritdoc />
    public partial class HeldItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) //when you run update db, it checks history table to see if migrations have been run. If it doesn't find this file, calls up method. 
        {
            migrationBuilder.AddColumn<string>(
                name: "Held_Item",
                table: "PokemonTeamMembers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Held_Item",
                table: "PokemonTeamMembers");
        }
    }
}
