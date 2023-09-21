using ConsoleApp1;
using ConsoleApp1.Controller;
using ConsoleApp1.Model;
using ConsoleApp1.Service;
using Newtonsoft.Json;
using RestSharp;
using ConsoleApp1.View;


public class Program
{
    public static void Main (string[] args)
    {
        TamagotchiController tamagotchiContoller = new TamagotchiController();
        tamagotchiContoller.Jogar();
    }

}
