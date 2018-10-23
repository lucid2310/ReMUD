using ReMUD.Game;
using ReMUD.Game.Managers;
using ReMUD.Game.Structures;
using System;

namespace ReMUD.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string rootDirectory = @"C:\Projects\GIT\ReMUD\DATs";
            rootDirectory = @"C:\WGSERV";

            
            GameManager gameManager = new GameManager();

            gameManager._init__wccmmud(rootDirectory);

            PlayerType newPlayer = gameManager._create_player("Maxx_One");

            gameManager.ContentManager.Select<PlayerManager>().Insert(newPlayer);

            Console.Read();
        }
    }
}
