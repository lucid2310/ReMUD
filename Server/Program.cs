using ReMUD.Game.Managers;
using System;

namespace ReMUD.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string rootDirectory = @"C:\Projects\GIT\ReMUD\DATs";

            MetaContentManager metaContentManager = new MetaContentManager();
            metaContentManager.Initialize(rootDirectory);


            Console.Read();
        }
    }
}
