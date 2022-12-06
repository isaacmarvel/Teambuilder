using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTeamBuilder.Core
{
    public class Item
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public Name[] PokemonsItems { get; set; }
    }
    public class ItemApiResult
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        public List<Item> Results { get; set; } 
    }
    public class ItemRootObject
    {
        public Attribute[] attributes { get; set; }
        public Effect_Entries[] effect_entries { get; set; }
        public Flavor_Text_Entries[] flavor_text_entries { get; set; }
        public object fling_effect { get; set; }
        public int fling_power { get; set; }
        public int id { get; set; }
        public object[] machines { get; set; }
        public string name { get; set; }
        public Name[] names { get; set; }
        public Sprites sprites { get; set; }
    }

    public class Attribute
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Effect_Entries
    {
        public string effect { get; set; }
        public string short_effect { get; set; }
    }

    public class Flavor_Text_Entries
    {
        public string text { get; set; }
    }


    public class ItemPokemon
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Name
    {
        public string name { get; set; }
    }
}
