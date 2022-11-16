using PokeTeamBuilder.Core;
using System.ComponentModel;
using System.Net.Http.Json;
using static MudBlazor.CategoryTypes;

namespace PokeTeamBuilder.Blazor.Pages
{
    public partial class NewTeam
    {
        private List<Pokemon> pokemon;
        private int offset = 0;

        protected async Task FetchPokemonList(int offset)
        {
            var apiResult = await Http.GetFromJsonAsync<PokemonApiResult>($"https://pokeapi.co/api/v2/pokemon/?offset={offset}");

            foreach(var p in apiResult.Results)
            {
                var pokemonDetails = await Http.GetFromJsonAsync<PokemonDetail>(p.Url);

                p.Url = pokemonDetails.sprites.front_default;
            }
            pokemon = apiResult.Results;
        }
        protected override async Task OnInitializedAsync()
        {
            await FetchPokemonList(offset);
        }

        //private Pokemon SelectedPokemon = new Pokemon()
        //{
        //    Name = "Bulbasaur",
        //    Url = "https://upload.wikimedia.org/wikipedia/commons/c/c0/Nicolas_Cage_Deauville_2013.jpg"
        //};

        private List<Pokemon> SelectedPokemon = new(); 
        private void AddToTeam(Pokemon pokemon)
        {
            if (SelectedPokemon.Count < 6)
            {
                SelectedPokemon.Add(pokemon);
            }
        }

        private void DeleteTeam()
        {
            SelectedPokemon.Clear();
            CurrentMon = null;
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
                await FetchPokemonList(offset);
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
                await FetchPokemonList(offset);
                await InvokeAsync(StateHasChanged);
            }
        }

        private Pokemon CurrentMon;
        private void ToggleStatCard(Pokemon mon)
        {
            CurrentMon = mon;
        }
        
    }

}