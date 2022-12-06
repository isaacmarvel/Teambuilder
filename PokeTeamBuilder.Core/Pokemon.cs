using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTeamBuilder.Core
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public string PokemonsSprite { get; set; }
        public Ability[] PokemonsAbilites { get; set; }
        public Move[] PokemonsMoves { get; set; }

        public string MyAbility { get; set; }
        public string MyMove1 { get; set; }
        public string MyMove2 { get; set; }
        public string MyMove3 { get; set; }
        public string MyMove4 { get; set; }
        public string MyHeld_Item { get; set; }

        public string MyNature { get; set; }

    }


    public class PokemonApiResult
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Pokemon> Results { get; set; }

    }




    public class Rootobject
    {
        public Ability[] abilities { get; set; }
        public object[] held_items { get; set; }
        public Move[] moves { get; set; }
        public string name { get; set; }
        public Sprites sprites { get; set; }
        public Stat[] stats { get; set; }

    }


    public class Sprites
    {
        public string front_default { get; set; }
    }

    public class Ability
    {
        public Ability1 ability { get; set; }
        public bool is_hidden { get; set; }
        public int slot { get; set; }
    }

    public class Ability1
    {
        public string name { get; set; }
        public string url { get; set; }
    }


    public class Move
    {
        public Move1 move { get; set; }
    }

    public class Move1
    {
        public string name { get; set; }
        public string url { get; set; }
    }



    public class Stat
    {
        public int base_stat { get; set; }
        public int effort { get; set; }
        public Stat1 stat { get; set; }
    }

    public class Stat1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
