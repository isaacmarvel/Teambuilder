namespace PokeTeamBuilder.BlazorServer.Data
{
    public class Team
    {
        public int Id { get; set; }
        public string? TeamName { get; set; }

        public List<PokemonTeamMember> PokemonTeamMembers { get; } = new();
    }
}
