using PokeTeamBuilder.Core;
using System.ComponentModel;
using System.Net.Http.Json;
using static MudBlazor.CategoryTypes;

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
        private List<string> PokemonTeamDetails = new();
        private void AddToTeam(string pokemonName, string pokemonUrl)
        {
            if (PokemonTeam.Count < 6)
            {
                PokemonTeam.Add(pokemonName);
                PokemonTeamDetails.Add(pokemonUrl);
            }

        }

        private void DeleteTeam()
        {
            foreach (var poke in PokemonTeam.ToList())
            {
                PokemonTeam.Remove(poke);
            }
            foreach (var poke in PokemonTeamDetails.ToList())
            {
                PokemonTeamDetails.Remove(poke);
            }
            InvokeAsync(StateHasChanged);
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
        private bool HideLabel { get; set; } = false;
        private string pokemon1;
        private string pokemon2;
        private string pokemon3;
        private string pokemon4;
        private string pokemon5;
        private string pokemon6;
        private void SetPokemon(int pokemonNumber)
        {
            foreach (var mon in PokemonTeam)
            {
                switch (pokemonNumber)
                {
                    case 1:
                        pokemon1 = mon;
                        break;
                    case 2:
                        pokemon2 = mon;
                        break;
                    case 3:
                        pokemon3 = mon;
                        break;
                    case 4:
                        pokemon4 = mon;
                        break;
                    case 5:
                        pokemon5 = mon;
                        break;
                    case 6:
                        pokemon6 = mon;
                        break;

                }
                Toggle();
                //next, set 6 html elements to show or hide based on each pokemon's data.
            }


        }

        private void Toggle()
        {
            HideLabel = !HideLabel;
        }

    }

}