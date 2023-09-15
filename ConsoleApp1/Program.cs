using ConsoleApp1;
using Newtonsoft.Json;
using RestSharp;
using System;

public class Program
{
    public static void Main (string[] args)
    {
        //Obter a lista de espécies de pokémons

        var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
        var request = new RestRequest(Method.GET);
        IRestResponse response = client.Execute(request);

        var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);

        //Apresentar as opções ao jogador
        Console.WriteLine("Escolha um Tamagotchi: ");
        for (int i = 0; i < pokemonEspeciesResposta.Results.Count; i++)
        {
            Console.WriteLine(i + 1 + "." + pokemonEspeciesResposta.Results[i].Name);
        }

        //Obter a escolha do jogador
        int escolha;



        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Escolha um número: ");
            if (!int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemonEspeciesResposta.Results.Count)
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }
            else
                break;
        }

        // Obter as características do Pokémon escolhido
        client = new RestClient($"https://pokeapi.co/api/v2/pokemon/" + escolha);
        request = new RestRequest(Method.GET);
        response = client.Execute(request);

        var pokemonDetalhes = JsonConvert.DeserializeObject<PokemonDetailsResults>(response.Content);

        var pokemonEscolhido = pokemonEspeciesResposta.Results[escolha - 1];

        //Mostrar as características ao jogador
        Console.WriteLine("\n");
        Console.WriteLine("Você escolheu " + pokemonEscolhido.Name + "!");
        Console.WriteLine("Detahles: ");
        Console.WriteLine("- Nome: " + pokemonEscolhido.Name);
        Console.WriteLine("- Peso: " + pokemonDetalhes.weight);
        Console.WriteLine("- Altura: " + pokemonDetalhes.Height);

        Console.WriteLine("\n Habilidades do Mascote: ");

        foreach(var abiliyDetail in pokemonDetalhes.Abilities)
        {
            Console.WriteLine("Nome da habilidade: " + abiliyDetail.Ability.Name);
        }

        Console.WriteLine("\n");
    }
}