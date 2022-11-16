using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace PokeTeamBuilder.Blazor.Data
{
    public class PokemonContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<PokemonTeamMember> PokemonTeamMembers { get; set; }

        public string DbPath { get; } //or this

        public PokemonContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Pokemon.db"); //may not need this
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=Pokemon.db"); //when db context is instantiated, will configure it with what we specify--so, use sqlite, and here's path.



    }
}
