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
        //Serve para usar a classe "PokemonResult" e obter uma lista de Pokémons disponíveis na API
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
            //Serve para pegar a url da API
            var request = new RestRequest(Method.GET);
            //Serve para fazer uma solicitação HTTP GET para a url da API que retorna as espécies de Pokémons
            IRestResponse response = client.Execute(request);
            //Serve para chamar o método "Execute(request)" e obter uma resposta do tipo "IRestResponse" 

            var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);
            //A resposta JSON é desserializada usando o JsonConvert.DeserializeObject para um objeto do tipo
            //PokemonSpeciesResult

            return pokemonEspeciesResposta.Results;
            //A lista de resultados Results dentro de PokemonSpeciesResult é retornada.
        }

        public PokemonDetailsResults ObterDetalhesDaEspecie(PokemonResult especie)
        //Serve para usar a classe "PokemonDetailsResults" e obter uma lista habilidades e outras informações relevantes
        {
            // Obter as características do Pokémon escolhido
            var client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{especie.Name}");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
                
            return JsonConvert.DeserializeObject<PokemonDetailsResults>(response.Content);

        }

    }
}
