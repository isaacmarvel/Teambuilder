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

        //Doesn't delete PokemonTeam
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
        private bool ShowLabel1 { get; set; } = true;
        private bool ShowLabel2 { get; set; } = true;
        private bool ShowLabel3 { get; set; } = true;
        private bool ShowLabel4 { get; set; } = true;
        private bool ShowLabel5 { get; set; } = true;
        private bool ShowLabel6 { get; set; } = true;

        //private void SetPokemon()
        //{
        //    foreach (var mon in PokemonTeam)
        //    {
        //        Toggle();
        //    }
        //}

        private void Toggle(string image)
        {
            if(image == PokemonTeamDetails[0])
            {
                ShowLabel1 = !ShowLabel1;
            } else if (image == PokemonTeamDetails[1])
            {
                ShowLabel2 = !ShowLabel2;
            }
            else if (image == PokemonTeamDetails[2])
            {
                ShowLabel3 = !ShowLabel3;
            } else if (image == PokemonTeamDetails[3])
            {
                ShowLabel4 = !ShowLabel4;
            }
            else if (image == PokemonTeamDetails[4])
            {
                ShowLabel5 = !ShowLabel5;
            }
            else if (image == PokemonTeamDetails[5])
            {
                ShowLabel6 = !ShowLabel6;
            }
            //ShowLabel = !ShowLabel;
        }
    }

}