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
            HideLabel1 = true;
            HideLabel2 = true;
            HideLabel3 = true;
            HideLabel4 = true;
            HideLabel5 = true;
            HideLabel6 = true;
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
        private bool HideLabel1 { get; set; } = true;
        private bool HideLabel2 { get; set; } = true;
        private bool HideLabel3 { get; set; } = true;
        private bool HideLabel4 { get; set; } = true;
        private bool HideLabel5 { get; set; } = true;
        private bool HideLabel6 { get; set; } = true;


        private void Toggle(string image)
        {
            if (image == PokemonTeamDetails[0])
            {
                HideLabel1 = !HideLabel1;
            }
            else if (image == PokemonTeamDetails[1])
            {
                HideLabel2 = !HideLabel2;
            }
            else if (image == PokemonTeamDetails[2])
            {
                HideLabel3 = !HideLabel3;
            }
            else if (image == PokemonTeamDetails[3])
            {
                HideLabel4 = !HideLabel4;
            }
            else if (image == PokemonTeamDetails[4])
            {
                HideLabel5 = !HideLabel5;
            }
            else if (image == PokemonTeamDetails[5])
            {
                HideLabel6 = !HideLabel6;
            }
        }
    }

}