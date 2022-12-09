using Microsoft.AspNetCore.Components;
using PokeTeamBuilder.BlazorServer.Data;
using PokeTeamBuilder.Core;


namespace PokeTeamBuilder.BlazorServer.Pages
{
    public partial class NewTeam
    {
        [Inject]
        private PokemonContext _context { get; set; }

        private List<Pokemon> pokemon;
        private List<Item> items;
        private List<Natures> natures;
        private int offset = 0;
        private string TeamName { get; set; } = "";
        private Pokemon CurrentMon;
        private List<Pokemon> SelectedPokemon = new();

        protected async Task PokeApiCall(int offset)
        {
            var PokemonApiResultProperty = await Http.GetFromJsonAsync<PokemonApiResult>($"https://pokeapi.co/api/v2/pokemon/?offset={offset}");
            pokemon = PokemonApiResultProperty.Results;

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

            var itemApiResultProperty = await Http.GetFromJsonAsync<ItemApiResult>($"https://pokeapi.co/api/v2/item/?limit=2000");
            items = itemApiResultProperty.Results;

            var natureApiResultProperty = await Http.GetFromJsonAsync<NatureApiResult>($"https://pokeapi.co/api/v2/nature/");
            natures = natureApiResultProperty.results;
        }
        protected override async Task OnInitializedAsync()
        {
            await PokeApiCall(offset);
        }


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


        private void SaveTeam()
        {
            var team = new Team();
            team.TeamName = TeamName;
            foreach (var mon in SelectedPokemon)
            {
                var teamMember = new PokemonTeamMember();
                teamMember.Name = mon.Name;
                teamMember.Ability = mon.MyAbility;
                teamMember.move1 = mon.MyMove1;
                teamMember.move2 = mon.MyMove2;
                teamMember.move3 = mon.MyMove3;
                teamMember.move4 = mon.MyMove4;
                teamMember.Held_Item = mon.MyHeld_Item;
                teamMember.Nature = mon.MyNature;
                teamMember.Sprite = mon.PokemonsSprite;
                team.PokemonTeamMembers.Add(teamMember);
            }
            _context.Add(team);
            _context.SaveChanges();
        }


    }
}
