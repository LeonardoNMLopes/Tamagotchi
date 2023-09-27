using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.View
{
    internal class TamagotchiView
    {
        public void MostrarMensagemDeBoasVindas()
        //serve para dar uma mensagem de boas-vindas ao jogador
        {
            Console.WriteLine("\n-------------");
            Console.WriteLine("Bem-vindo ao jogo de adoção de mascotes! ");
            Console.WriteLine("Por favor, digite seu nome: ");
            string nomeJogador = Console.ReadLine();
            Console.WriteLine("Olá, " + nomeJogador + "! Vamos começar"!);
        }

        public void MostrarMenuPrincipal()
        //Serve para mostrar o menu principal   
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Menu Principal:");
            Console.WriteLine("1. Adotar um Mascote");
            Console.WriteLine("2. Interagir com seu Mascote");
            Console.WriteLine("3. Ver Mascotes Adotados");
            Console.WriteLine("4. Sair do Jogo");
            Console.Write("Escolha uma opção: ");
        }

        public void MostrarMenuDeInteracao()
        //Serve para mostrar o menu de interação com o tamagotchi
        {
            Console.WriteLine("\n--------------");
            Console.WriteLine("Menu de Interação: ");
            Console.WriteLine("1. Saber como o mascote está");
            Console.WriteLine("2. Alimentar o mascote");
            Console.WriteLine("3. Brincar com o mascote");
            Console.WriteLine("4. Dormir zzzz");
            Console.WriteLine("5. Dar carinho :3 ");
            Console.WriteLine("6. Voltar");
            Console.WriteLine("Escolha uma opção: ");
        }

        public int ObterEscolhaDoJogador(int maxOpcao)
        //Serve para obter a escolha do jogador, que só pode ser um numero entre 1 e o maximo de opções
        {
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > maxOpcao)
            {
                Console.WriteLine("Escolha inválida. Por favor, escolha uma opção entre 1 e " + maxOpcao+ ": ");
            }
            return escolha;
        }

        public void MostrarMenuDeAdocao()
        //Serve para obter o menu de adoção
        {
            Console.WriteLine("\n-------------");
            Console.WriteLine("Menu de Adoção de Mascotes: ");
            Console.WriteLine("1. Ver especies diponíveis");
            Console.WriteLine("2. ver detalhes de uma espécie");
            Console.WriteLine("3. Adotar um Mascote");
            Console.WriteLine("4. Voltar ao menu principal");
            Console.WriteLine("Escolha uma opção: ");
        }

        public void MostrarEspeciesDisponiveis(List<PokemonResult> especies)
        //Serve para obter uma lista de espécies de pokémons disponíveis para a adoção
        {
            Console.WriteLine("\n------------");
            Console.WriteLine("Especies disponíveis para adoção: ");
            for (int i = 0; i < especies.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + especies[i].Name);
            }
        }

        public void MostrarDetalhesDaEspecie(PokemonDetailsResults detalhes)
        //Serve para pegar as informaçãoes do Pokémon escolhido
        {
            Console.WriteLine("\n------------");
            Console.WriteLine("Detalhes da Especie: ");
            Console.WriteLine("Nome: " + detalhes.Name);
            Console.WriteLine("Altura: " + detalhes.Height);
            Console.WriteLine("Peso: " + detalhes.Weight);
            Console.WriteLine("Habilidades: ");

            foreach (var habilidades in detalhes.Abilities)
            //Serve para vasculhar as habilidades do Pokémon escolhido usado detalhes ".Abilities" da classe "PokemonDetailResults"
            {
                Console.WriteLine("- " + habilidades.Ability.Name);
            }
        }

        public bool ConfirmarAdocao()
        //Serve para obter a resposta do jogador sobre adotar ou não
        {
            Console.WriteLine("\n ──────────────");
            Console.Write("Você gostaria de adotar este mascote? (s/n): ");
            string resposta = Console.ReadLine();
            return resposta.ToLower() == "s";
        }

        public void MostrarMascotesAdotados(List<TamagotchiDto> mascotesAdotados)
        //Serve para obter a lista de Pokémons adotados pelo jogador, caso não haja uma mensagem sera mostrada
        {
            Console.WriteLine("\n ──────────────");
            Console.WriteLine("Mascotes Adotados:");
            if (mascotesAdotados.Count == 0)
            {
                Console.WriteLine("Você ainda não adotou nenhum mascote.");
            }
            else
            {
                for (int i = 0; i < mascotesAdotados.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + mascotesAdotados[i].Nome);
                }
            }
        }
        public int ObterEspecieEscolhida(List<PokemonResult> especies)
        //Serve para obter o Pokémon escolhido pelo jogador
        {
            Console.WriteLine("\n ──────────────");
            int escolha;
            while (true)
            {
                Console.Write("Escolha uma espécie pelo número (1-" + especies.Count + "): ");
                if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= especies.Count)
                {
                    break;
                }
                Console.WriteLine("Escolha inválida.");
            }
            return escolha - 1;
            // Ajuste para índice baseado em 0, pois a contagem começa no zero, e na API no 1
        }

    }
}
