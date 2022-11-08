using Newtonsoft.Json;

namespace PokeTeamBuilder.Core
{
    public class PokemonAPIClient
    {
        public async Task<PokemonApiResult> ListPokemon(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var pokemonApiResult = JsonConvert.DeserializeObject<PokemonApiResult>(responseBody);

            return pokemonApiResult;
        }
    }
}
