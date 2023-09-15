using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PokemonDetailsResults
    {
        public List<AbilityDetail> Abilities { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Height { get; set; }
        public int weight { get; set; }
    }
    public class AbilityDetail
    {
        public Ability Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }
    public class Ability
    {
        public string Name { get; set; }
        public string Url { get; set; }

    }
}   

