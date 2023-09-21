using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    internal class PokemonDetailsResults
    {
        public List<AbilityDetail> Abilities { get; set; }
        //Serve para pegar uma lista de habilidades em detalhes de um Pokémon
        public string Name { get; set; }
        //Serve para pegar o nome do Pokémon
        public int Order { get; set; }
        //Serve para pegar o numero do Pokémon dentro da API
        public int Height { get; set; }
        //Serve para pegar a altura do Pokémon
        public int Weight { get; set; }
        //Serve para pegar o peso do Pokémon
    }
    public class AbilityDetail
    {
        public Ability Ability { get; set; }
        //Serve para armazenar a habilidade do Pokémon
        public bool IsHidden { get; set; }
        //Seve para pegar um valor booleano que indica se a habilidade e oculta ou não
        public int Slot { get; set; }
        //Serve para pegar a pocisão da habilidade 
    }
    public class Ability
    {
        public string Name { get; set; }
        //Serve para pegar o nome da habilidade 
        public string Url { get; set; }
        //Serve para pegar o url associado da habilidade na API

    }
}

