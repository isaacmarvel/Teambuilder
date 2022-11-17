namespace PokeTeamBuilder.BlazorServer.Data
{
    public class PokemonTeamMember
    {
        public int Id { get; set; } //do these need to have pokemon types?
        public string Name { get; set; }
        public string Ability { get; set; }
        public string move1 { get; set; }
        public string move2 { get; set; }
        public string move3 { get; set; }
        public string move4 { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
