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

        public string MySprite { get; set; }
        public Ability[] MyAbilities { get; set; }

        public Move[] MyMoves { get; set; }

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
        public int base_experience { get; set; }
        public Game_Indices[] game_indices { get; set; }
        public int height { get; set; }
        public object[] held_items { get; set; }
        public int id { get; set; }
        public bool is_default { get; set; }
        public string location_area_encounters { get; set; }
        public Move[] moves { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public object[] past_types { get; set; }
        public Sprites sprites { get; set; }
        public Stat[] stats { get; set; }
        public Type[] types { get; set; }
        public int weight { get; set; }
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

    public class Game_Indices
    {
        public int game_index { get; set; }
        public Version version { get; set; }
    }

    public class Version
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Move
    {
        public Move1 move { get; set; }
        public Version_Group_Details[] version_group_details { get; set; }
    }

    public class Move1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version_Group_Details
    {
        public int level_learned_at { get; set; }
        public Move_Learn_Method move_learn_method { get; set; }
        public Version_Group version_group { get; set; }
    }

    public class Move_Learn_Method
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version_Group
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

    public class Type
    {
        public int slot { get; set; }
        public Type1 type { get; set; }
    }

    public class Type1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
