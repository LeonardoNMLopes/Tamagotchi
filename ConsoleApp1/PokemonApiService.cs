using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class PokemonApiService
    {
        public List<PokemonResult> ObterEspeciesDisponiveis()
        {
            // Obter a lista de espécies de pokémons 
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);

            return pokemonEspeciesResposta.Results;
        }

        public PokemonDetailsResults ObterDetalhesDaEspecie(PokemonResult especie)
        {
            // Obter as características do Pokémon escolhido
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie.Name}");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<PokemonDetailsResults>(response.Content);

        }

    }
}
