using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class PokemonSpeciesResult
    {
        public int Count { get; set; }
        //Serve para pegar o numero total de Pokémons
        public string Next { get; set; }
        //Serve para ir ao proximo Pokémon
        public string Previous { get; set; }
        //Serve para ir ao Pokémon anterior 
        public List<PokemonResult> Results { get; set; }
        //Serve para pegar uma lista de Pokémons na API
    }
}
