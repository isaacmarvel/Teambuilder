using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTeamBuilder.Core
{
    public class Natures
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    public class NatureApiResult
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Natures> results { get; set; }
    }

    public class Root
    {
        public DecreasedStat decreased_stat { get; set; }
        public HatesFlavor hates_flavor { get; set; }
        public int id { get; set; }
        public IncreasedStat increased_stat { get; set; }
        public LikesFlavor likes_flavor { get; set; }
        public List<MoveBattleStylePreference> move_battle_style_preferences { get; set; }
        public string name { get; set; }
        public List<Name> names { get; set; }
        public List<PokeathlonStatChange> pokeathlon_stat_changes { get; set; }
    }

    public class DecreasedStat
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class HatesFlavor
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class IncreasedStat
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class LikesFlavor
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class MoveBattleStyle
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class MoveBattleStylePreference
    {
        public int high_hp_preference { get; set; }
        public int low_hp_preference { get; set; }
        public MoveBattleStyle move_battle_style { get; set; }
    }

    public class NatureName
    {
        public Language language { get; set; }
        public string name { get; set; }
    }

    public class PokeathlonStat
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokeathlonStatChange
    {
        public int max_change { get; set; }
        public PokeathlonStat pokeathlon_stat { get; set; }
    }

   


}
