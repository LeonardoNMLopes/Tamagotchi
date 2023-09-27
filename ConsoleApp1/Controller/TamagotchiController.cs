using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;
using ConsoleApp1.Service;
using ConsoleApp1.View;

namespace ConsoleApp1.Controller
{
    public class TamagotchiController
    {
        private TamagotchiView tamagotchiView { get; set; }
        private PokemonApiService pokemonApiService { get; set; }
        private List<PokemonResult> especiesDisponiveis { get; set; }

        private List<TamagotchiDto> mascotesAdotados { get; set; }

        IMapper mapper { get; set; }

        public TamagotchiController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            mapper = config.CreateMapper();

            tamagotchiView = new TamagotchiView();
            pokemonApiService = new PokemonApiService();
            especiesDisponiveis = pokemonApiService.ObterEspeciesDisponiveis();
            mascotesAdotados = new List<TamagotchiDto>();
        }

        public void Jogar()
        {
            tamagotchiView.MostrarMensagemDeBoasVindas();

            while (true)
            {
                tamagotchiView.MostrarMenuPrincipal();
                int escolha = tamagotchiView.ObterEscolhaDoJogador(4);

                switch (escolha)
                {
                    case 1:
                        while (true)
                        {
                            tamagotchiView.MostrarMenuDeAdocao();
                            escolha = tamagotchiView.ObterEscolhaDoJogador(4);
                            switch (escolha)
                            {
                                case 1:
                                    tamagotchiView.MostrarEspeciesDisponiveis(especiesDisponiveis);
                                    break;
                                case 2:
                                    tamagotchiView.MostrarEspeciesDisponiveis(especiesDisponiveis);
                                    int indiceEspecie = tamagotchiView.ObterEspecieEscolhida(especiesDisponiveis);
                                    PokemonDetailsResults detalhes = pokemonApiService.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
                                    tamagotchiView.MostrarDetalhesDaEspecie(detalhes);
                                    break;
                                case 3:
                                    tamagotchiView.MostrarEspeciesDisponiveis(especiesDisponiveis);
                                    indiceEspecie = tamagotchiView.ObterEspecieEscolhida(especiesDisponiveis);
                                    detalhes = pokemonApiService.ObterDetalhesDaEspecie(especiesDisponiveis[indiceEspecie]);
                                    tamagotchiView.MostrarDetalhesDaEspecie(detalhes);
                                    if (tamagotchiView.ConfirmarAdocao())
                                    {
                                        TamagotchiDto tamagotchi = mapper.Map<TamagotchiDto>(detalhes);
                                        mascotesAdotados.Add(tamagotchi);

                                        Console.WriteLine("Parabéns! Você adotou um " + detalhes.Name + "!");
                                        Console.WriteLine("──────────────");
                                        Console.WriteLine("────▄████▄────");
                                        Console.WriteLine("──▄████████▄──");
                                        Console.WriteLine("──██████████──");
                                        Console.WriteLine("──▀████████▀──");
                                        Console.WriteLine("─────▀██▀─────");
                                        Console.WriteLine("──────────────");
                                    }
                                    break;
                                case 4:
                                    break;
                            }
                            if (escolha == 4)
                            {
                                break;
                            }
                        }
                        break;
                    case 2:
                        if (mascotesAdotados.Count == 0)
                        {
                            Console.WriteLine("Você não tem nenhum mascote adotado.");
                            break;
                        }

                        Console.WriteLine("Escolha um mascote para interagir:");
                        for (int i = 0; i < mascotesAdotados.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {mascotesAdotados[i].Nome}");
                        }

                        int indiceMascote = tamagotchiView.ObterEscolhaDoJogador(mascotesAdotados.Count) - 1;
                        TamagotchiDto mascoteEscolhido = mascotesAdotados[indiceMascote];

                        int opcaoInteracao = 0;
                        while (opcaoInteracao != 6)
                        {
                            tamagotchiView.MostrarMenuDeInteracao();
                            opcaoInteracao = tamagotchiView.ObterEscolhaDoJogador(6);

                            switch (opcaoInteracao)
                            {
                                case 1:
                                    mascoteEscolhido.MostrarStatus();
                                    break;
                                case 2:
                                    mascoteEscolhido.Alimentar();
                                    break;
                                case 3:
                                    mascoteEscolhido.Brincar();
                                    break;
                                case 4:
                                    mascoteEscolhido.Descansar();
                                    break;
                                case 5:
                                    mascoteEscolhido.DarCarinho();
                                    break;
                            }
                        }
                        break;

                    case 3:
                        tamagotchiView.MostrarMascotesAdotados(mascotesAdotados);
                        break;
                    case 4:
                        Console.WriteLine("Obrigado por jogar! Até a próxima!");
                        return;
                }
            }
        }


    }
}
