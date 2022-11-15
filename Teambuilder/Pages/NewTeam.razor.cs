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

        private List<string> PokemonTeam = new(); //can you set a default value for a list item? Default if empty?
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
        private bool ShowLabel { get; set; } = true;

        private void SetPokemon()
        {
            foreach (var mon in PokemonTeam)
            {
                Toggle();
            }
        }

        private void Toggle()
        {
            ShowLabel = !ShowLabel;
        }
    }

}