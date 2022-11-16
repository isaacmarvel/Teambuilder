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

        //have a property that is selected pokemon, bind it to card on page
        //then in toggle, set that to be whatever pokemon that is that needs to be displayed, or null
        //may wannad oa null check
        //have toggle method set selected property to something different

        //might want a model that represents an individual pokemon, has property for name, image, stats
        //so you'd end up with type pokemon instead of strings
        
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