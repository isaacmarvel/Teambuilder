namespace PokeTeamBuilder.Blazor.Data
{
    public class Team
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public List<PokemonTeamMember> PokemonTeamMember { get; } = new();
    }
}
