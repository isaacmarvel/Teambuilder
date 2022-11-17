// See https://aka.ms/new-console-template for more information
//Console app to test api goes here

using PokeTeamBuilder.Core;

//var pokemonClient = new PokemonAPIClient();
//var response = await pokemonClient.ListPokemon("https://pokeapi.co/api/v2/pokemon/");



//foreach (var pokemon in response.Results)
//{
//    Console.WriteLine(pokemon.Name);
//}
//Console.ReadLine();

var pokemonClient = new PokemonAPIClient();
var response = await pokemonClient.ListPokemon("https://pokeapi.co/api/v2/item/");



foreach (var pokemon in response.Results)
{
    Console.WriteLine(pokemon.Name);
}
Console.ReadLine();




