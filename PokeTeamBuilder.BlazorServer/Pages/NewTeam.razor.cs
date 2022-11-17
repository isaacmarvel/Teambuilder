using PokeTeamBuilder.Core;

namespace PokeTeamBuilder.BlazorServer.Pages
{
    public partial class NewTeam
    {
        private List<Pokemon> pokemon; //may not need these
        private List<Item> items = new();
        private int offset = 0;

        protected async Task PokeApiCall(int offset)
        {
            var PokemonApiResultProperty = await Http.GetFromJsonAsync<PokemonApiResult>($"https://pokeapi.co/api/v2/pokemon/?offset={offset}");

            foreach (var p in PokemonApiResultProperty.Results)
            {
                var pokemonDetails = await Http.GetFromJsonAsync<Rootobject>(p.Url);

                p.PokemonsSprite = pokemonDetails.sprites.front_default;
            }

            foreach (var p in PokemonApiResultProperty.Results)
            {
                var pokemonDetails = await Http.GetFromJsonAsync<Rootobject>(p.Url);

                p.PokemonsAbilites = pokemonDetails.abilities;
            }

            foreach (var p in PokemonApiResultProperty.Results)
            {
                var pokemonDetails = await Http.GetFromJsonAsync<Rootobject>(p.Url);

                p.PokemonsMoves = pokemonDetails.moves;
            }

            pokemon = PokemonApiResultProperty.Results;

            var itemApiResultProperty = await Http.GetFromJsonAsync<ItemApiResult>($"https://pokeapi.co/api/v2/item/?limit=2000");

            //foreach (var i in itemApiResultProperty.Results)
            //{
            //    var itemDetails = await Http.GetFromJsonAsync<ItemRootObject>(i.Url);
            //    i.PokemonsItems = itemDetails.names;
            //}

            items = itemApiResultProperty.Results;
        }

        //protected async Task PokeItemCall()
        //{
        //    var itemApiResultProperty = await Http.GetFromJsonAsync<ItemApiResult>($"https://pokeapi.co/api/v2/item/");

        //    foreach (var i in itemApiResultProperty.Results)
        //    {
        //        var itemDetails = await Http.GetFromJsonAsync<ItemRootObject>(i.Url);
        //        i.PokemonsItems = itemDetails.names;
        //    }

        //    items = itemApiResultProperty.Results;
        //}
        protected override async Task OnInitializedAsync()
        {
            await PokeApiCall(offset);
        }

        private List<Pokemon> SelectedPokemon = new();
        private void AddToTeam(Pokemon pokemon)
        {
            if (SelectedPokemon.Count < 6 && !SelectedPokemon.Contains(pokemon))
            {
                SelectedPokemon.Add(pokemon);
            }
        }

        private void DeleteTeam()
        {
            SelectedPokemon.Clear();
            CurrentMon = null;
            PokemonTeamMembers.Clear();
        }

        private int IncrementOffset()
        {
            offset += 20;
            return offset;
        }
        private async Task NextButton()
        {
            if (offset > 1154)
            {
                Console.WriteLine("You're at the end!");
            }
            else
            {
                IncrementOffset();
                await PokeApiCall(offset);
                await InvokeAsync(StateHasChanged);
            }

        }

        private int ReduceOffset()
        {
            offset -= 20;
            return offset;
        }
        private async Task PreviousButton()
        {
            if (offset < 20)
            {
                Console.WriteLine("You're already at the beginning!");
            }
            else
            {
                ReduceOffset();
                await PokeApiCall(offset);
                await InvokeAsync(StateHasChanged);
            }
        }

        private Pokemon CurrentMon;

        private List<Pokemon> PokemonTeamMembers = new();
        private void ToggleStatCard(Pokemon mon)
        {
            if (CurrentMon == null)
            {
                CurrentMon = mon;
            }
            else if (!PokemonTeamMembers.Contains(CurrentMon) && (PokemonTeamMembers.Count < 7))
            {
                PokemonTeamMembers.Add(CurrentMon);
                CurrentMon = mon;
            }
            else if (PokemonTeamMembers.Contains(CurrentMon))
            {
                CurrentMon = mon;
            }
            else if (mon == null)
            {
                PokemonTeamMembers.Add(CurrentMon);
                CurrentMon = mon;
                //save team to db
            }
        }


    }
}
