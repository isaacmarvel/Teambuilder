﻿using Microsoft.EntityFrameworkCore;

namespace PokeTeamBuilder.BlazorServer.Data
{
        public class PokemonContext : DbContext
        {
            public DbSet<Team> Teams { get; set; } //Db.Teams is basically a list, has linq methods
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
