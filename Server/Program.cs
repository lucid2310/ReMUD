using ReMUD.Game;
using ReMUD.Game.Managers;
using ReMUD.Game.Structures;
using ReMUD.Game.Tests;
using System;

namespace ReMUD.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();

            string rootDirectory = @"C:\Projects\GIT\ReMUD\DATs";
            rootDirectory = @"C:\WGSERV";

            //string[] FirstNames = { "John", "Peter", "Jason", "Andrew", "Richard" };
            //string[] LastNames = { "Lannister", "Targaryen", "Snow", "Stark", "Mormont", "Tarly", "Greyjoy" };

            //int indexFirstName = rand.Next(FirstNames.Length);
            //int indexLastName = rand.Next(LastNames.Length);

            // GameManager gameManager = new GameManager();

            //gameManager._init__wccmmud(rootDirectory);

            //PlayerType player = gameManager.ContentManager.Select<PlayerManager>().Select("Lucid");

            //string rngName = FirstNames[indexFirstName] + "_" + LastNames[indexLastName];

            //PlayerType newPlayer = gameManager._create_player(rngName);

            //gameManager.ContentManager.Select<PlayerManager>().Insert(newPlayer);

            //gameManager._calculate_secondary_stats(ref player);

            PlayerTestProcedures.ConvertCurrency_TC01();
            PlayerTestProcedures.ConvertCurrency_TC02();
            PlayerTestProcedures.GetCoinWeight_TC01();

            Console.Read();
        }

      
    }
}
