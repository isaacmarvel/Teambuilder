using PokeTeamBuilder.Core;
using System.ComponentModel;
using System.Net.Http.Json;

namespace PokeTeamBuilder.Blazor.Pages
{
    public partial class NewTeam
    {
        private PokemonApiResult _pokemons;
        private PokemonDetail pokemonDetails;
        private int offset = 0;

        protected async Task FetchPokemonList(int offset)
        {
            _pokemons = await Http.GetFromJsonAsync<PokemonApiResult>($"https://pokeapi.co/api/v2/pokemon/?offset={offset}");
            foreach (var poke in _pokemons.Results)
            {
                pokemonDetails = await Http.GetFromJsonAsync<PokemonDetail>(poke.Url);

                poke.Url = pokemonDetails.sprites.front_default;
            }
        }
        protected override async Task OnInitializedAsync()
        {
            await FetchPokemonList(offset);
        }

        

        private List<string> PokemonTeam = new();
        private void SetPokemon(string pokemon)
        {
            if (PokemonTeam.Count < 7)
            {
                PokemonTeam.Add(pokemon);
            }

        }

        private async Task NextButton(int offset)
        {
            offset = 20;
            await FetchPokemonList(offset);
            await InvokeAsync(StateHasChanged);
        }

        //private void PreviousButton(int offset)
        //{

        //}

    }
}




//        private PokemonList pokemons;
//        private PokemonDetail pokemonDetails;
//        private int limit = 20;
//        private int offset = 0;

//        public void Paginate(int value)
//        {
//            Console.WriteLine(value);
//            this.offset = value;
//            InvokeAsync(StateHasChanged);
//        }

//        private async Task FetchPokemonList()
//        {
//            pokemons = await Http.GetFromJsonAsync<PokemonList>($"https://pokeapi.co/api/v2/pokemon/?offset={offset}&limit={limit}");

//            foreach (var p in pokemons.results)
//            {
//                pokemonDetails = await Http.GetFromJsonAsync<PokemonDetail>(p.url);

//                p.url = pokemonDetails.sprites.front_default;
//            }
//        }
//        protected override async Task OnInitializedAsync()
//        {
//            await FetchPokemonList();
//        }

//        public class PokemonList
//        {
//            public int count { get; set; }
//            public string next { get; set; }
//            public List<Pokemon> results { get; set; }
//        }

//        public class Pokemon
//        {
//            public string name { get; set; }
//            public string url { get; set; }
//        }

//        public class PokemonDetail
//        {
//            public PokemonSprites sprites { get; set; }
//        }

//        public class PokemonSprites
//        {
//            public string front_default { get; set; }
//        }
//    }
//}
