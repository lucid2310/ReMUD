using ReMUD.Game;
using ReMUD.Game.Structures;
using ReMUD.Game.Utilities;
using ReMUD.Module.Managers;
using ReMUD.Server.Managers;
using ReMUD.Server.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;


namespace ReMUD.Server
{
    public class Program
    {
        public static Dictionary<string, GameServer> Servers = new Dictionary<string, GameServer>();

        public static void Main(string[] args)
        {


            //IntPtr pPointer = IntPtr.Zero;

            ////_init_emulation(pPointer);
            //string methodName = "_init__wccmmud";

            //string moduleName = @"C:\wgserv\wccmmud.dll";
            ///// Assembly testAssembly = Assembly.LoadFile(@moduleName);
            //// IntPtr hEzdDLL = LoadLibrary(moduleName);

            //var handle = PInvoke.Kernel32.LoadLibraryEx(moduleName, IntPtr.Zero, PInvoke.Kernel32.LoadLibraryExFlags.LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR);

            //var ppt = PInvoke.Kernel32.GetProcAddress(handle, methodName);


            //_init__wccmmud drs = (_init__wccmmud)Marshal.GetDelegateForFunctionPointer(ppt, typeof(_init__wccmmud));

            //drs.Invoke();

           // drs(); // call via a function pointer
            //

            //Console.WriteLine(fileName);

            Random rand = new Random();

            string rootDirectory = @"C:\Projects\GIT\ReMUD\DATs";
            rootDirectory = @"C:\WGSERV";

            // UserManager.LoadUsers();

            #region Prototype Code
            //string[] FirstNames = { "John", "Peter", "Jason", "Andrew", "Richard" };
            //string[] LastNames = { "Lannister", "Targaryen", "Snow", "Stark", "Mormont", "Tarly", "Greyjoy" };

            //int indexFirstName = rand.Next(FirstNames.Length);
            //int indexLastName = rand.Next(LastNames.Length);

            //PlayerType player = gameManager.ContentManager.Select<PlayerManager>().Select("Lucid");

            //string rngName = FirstNames[indexFirstName] + "_" + LastNames[indexLastName];

            //PlayerType newPlayer = gameManager._create_player(rngName);

            //gameManager.ContentManager.Select<PlayerManager>().Insert(newPlayer);

            //gameManager._calculate_secondary_stats(ref player);

            //PlayerTestProcedures.InitializeGameManager(rootDirectory);
            //PlayerTestProcedures.GetLegalLevel_TP01();

            //PlayerTestProcedures.AddDelay_TP01();

            //PlayerTestProcedures.ConvertCurrency_TC01();
            //PlayerTestProcedures.ConvertCurrency_TC02();
            //PlayerTestProcedures.GetCoinWeight_TC01();
            //PlayerTestProcedures.CheckPlayerStruction_TC01();


            GameManager gameManager = new GameManager();


            int results = gameManager._stat_amount_used(35, 95);

          //  gameManager._init__wccmmud(rootDirectory);

            //PlayerType player = gameManager._create_player("maxx");

            //player.Race = 1;
            //player.Class = 1;
            //player.Level = 25;
            //SpellType spell = gameManager._get_spell_data(9).Value;

            ////gameManager._add_cast_spell_to_user(player, 0, 0, spell);

            //int spellMod = gameManager._get_spell_random_modifier(player, spell);

            //PlayerType newPlayer = PlayerType.Initialize();

            //newPlayer.Class = 1;
            //newPlayer.Race = 1;
            //newPlayer.SpellCasted[0] = 131;
            //newPlayer.SpellRoundsLeft[0] = 5;
            //newPlayer.SpellValue[0] = 1;
            //newPlayer.SetFirstName("maxx");

            //gameManager._check_confusion(newPlayer);


            //// gameManager._edit_character_stats();
            #endregion

            //InitializeServer(23, "Test", rootDirectory);

            ////CustomFileUtility.GetDisplay(110, 127);
            ////DatabaseManager.CalculateMD5Hash("pass123");
            Console.Read();
        }

        public static void InitializeServer(int port, string name, string directory)
        {
            Servers.Add(name,  new GameServer(port, name, directory));

            foreach(var server in Servers)
            {
                server.Value.Initialize();
            }
        }
    }
}
