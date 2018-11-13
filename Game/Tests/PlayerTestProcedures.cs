using ReMUD.Game.Managers;
using ReMUD.Game.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ReMUD.Game.Tests
{
    public static class PlayerTestProcedures
    {
        public static void ConvertCurrency_TC01()
        {
            // all currency normalized to copper.
            object expectedValue = 1010111;
            object actualValue = 0;

            GameManager gameManager = new GameManager();

            PlayerType player = PlayerType.Initialize();

            player.Runic = 1;
            player.Platinum = 1;
            player.Gold = 1;
            player.Silver = 1;
            player.Copper = 1;

            actualValue = gameManager._get_user_currency(player);

            Console.WriteLine("Test {0} Status = {1}", MethodBase.GetCurrentMethod().Name, actualValue.ToString().Equals(expectedValue.ToString()) == true ? "Pass" : "Fail");
        }

        public static void ConvertCurrency_TC02()
        {
            // all currency normalized to copper.
            object expectedValue = 101011100;
            object actualValue = 0;

            GameManager gameManager = new GameManager();

            PlayerType player = PlayerType.Initialize();

            int maxValue = 100;

            player.Runic = maxValue;
            player.Platinum = maxValue;
            player.Gold = maxValue;
            player.Silver = maxValue;
            player.Copper = maxValue;

            actualValue = gameManager._get_user_currency(player);

            Console.WriteLine("Test {0} Status = {1}", MethodBase.GetCurrentMethod().Name, actualValue.ToString().Equals(expectedValue.ToString()) == true ? "Pass" : "Fail");
        }

        public static void CheckPlayerStruction_TC01()
        {
            PlayerManager playerManager = new PlayerManager();

            playerManager.Initialize(@"C:\Projects\GIT\ReMUD\DATs\InputFiles");

            PlayerType player = playerManager.Select("Andrew_Stark");

            bool results = (player.AbilityId[0] == 0 && player.AbilityValue[0] == 1);
            results &= (player.AbilityId[10] == 10 && player.AbilityValue[10] == 11);
            results &= (player.AbilityId[20] == 20 && player.AbilityValue[20] == 21);

            results &= (player.CurrentHitpoints == 1000 && player.MaximumHitpoints == 1000);
            results &= (player.CurrentMana == 220 && player.MaxMana == 220);

            // Primary Stats.
            results &= (player.Strength == 1 && player.MaxStrength == 2);
            results &= (player.Intellect == 3 && player.MaxIntellect == 4);
            results &= (player.WillPower == 5 && player.MaxWillPower == 6);
            results &= (player.Agility == 7 && player.MaxAgility == 8);
            results &= (player.Health == 9 && player.MaxHealth == 10);
            results &= (player.Charm == 11 && player.MaxCharm == 12);

            // Secondary Stats.
            results &= (player.Perception == 1 && player.Stealth == 2);
            results &= (player.Thievery == 3 && player.Traps == 4);
            results &= (player.Picklocks == 5 && player.Tracking == 6);
            results &= (player.MartialArts == 7 && player.MagicRes == 8);

            // Inventory
            results &= (player.Item[0] == 9 && player.Item[99] == 50);           
            results &= (player.Key[0] == 172 && player.Key[49] == 177);
            results &= (player.KeyUses[0] == 10 && player.KeyUses[49] == 10);

            // Worn
            results &= (player.WornItem[0] == 23 && player.WornItem[19] == 30);
            results &= (player.WeaponHand == 100);

            // Spells.
            results &= (player.Spell[0] == 41 && player.Spell[99] == 42);
            results &= (player.Spell[0] == 41 && player.Spell[99] == 42);

            // Spells Cast
            results &= (player.SpellCasted[0] == 48 && player.SpellRoundsLeft[0] == 10 && player.SpellValue[0] == 10);
            results &= (player.SpellCasted[9] == 100 && player.SpellRoundsLeft[9] == 20 && player.SpellValue[9] == 20);

            // Rooms
            results &= (player.LastMap[0] == 1 && player.LastRoom[0] == 1);
            results &= (player.LastMap[19] == 1 && player.LastRoom[19] == 298);
            results &= (player.MapNumber == 1 && player.RoomNumber == 2140);

            results &= (player.SuicidePassword[0] == '0' && player.SuicidePassword[1] == '1');
            results &= (player.SuicidePassword[2] == '2' && player.SuicidePassword[3] == '3');
            results &= (player.SuicidePassword[4] == '4' && player.SuicidePassword[5] == '5');
            results &= (player.SuicidePassword[6] == '6' && player.SuicidePassword[7] == '7');

            results &= (player.Runic == 9 && player.Platinum == 8);
            results &= (player.Gold == 7 && player.Silver == 6);
            results &= (player.Copper == 5);

            results &= (player.CurrentEncumbrance == 250 && player.MaximumEncumbrance == 500);

            // gang name.
            results &= (player.GangName[0] == 't' && player.GangName[1] == 'e');
            results &= (player.GangName[2] == 's' && player.GangName[3] == 't');
            results &= (player.GangName[4] == '_' && player.GangName[5] == 'g');
            results &= (player.GangName[6] == 'a' && player.GangName[7] == 'n');
            results &= (player.GangName[8] == 'g');

            // title.
            results &= (player.Title[0] == 'A' && player.Title[1] =='p');
            results &= (player.Title[2] == 'p' && player.Title[3] == 'r');
            results &= (player.Title[4] == 'e' && player.Title[5] == 'n');
            results &= (player.Title[6] == 't' && player.Title[7] == 'i');
            results &= (player.Title[8] == 'c' && player.Title[9] == 'e');

            results &= (player.EditFlag == 1);

            results &= (player.MillionsOfExperience == 100);
            results &= (player.Level == 1);
            results &= (player.CPRemaining == 100);
            results &= (player.Race == 1);
            results &= (player.Class == 9);
            results &= (player.LivesRemaining == 9);

            results &= (player.Username[0] == 'A' && player.Username[1] == 'n');
            results &= (player.Username[2] == 'd' && player.Username[3] == 'r');
            results &= (player.Username[4] == 'e' && player.Username[5] == 'w');
            results &= (player.Username[6] == '_' && player.Username[7] == 'S');
            results &= (player.Username[8] == 't' && player.Username[9] == 'a');
            results &= (player.Username[10] == 'r' && player.Username[11] == 'k');

            results &= (player.SpellCasting == 253);

            results &= (player.EvilPoints == -233);
            results &= (player.BroadcastChannel == 456);

            Console.WriteLine("Player Structure Test Status = {0}", results == true ? "Pass" : "Fail");

        }

        public static void GetCoinWeight_TC01()
        {
            // all currency normalized to copper.
            object expectedValue = 165;
            object actualValue = 0;

            GameManager gameManager = new GameManager();

            PlayerType player = PlayerType.Initialize();

            int maxValue = 100;

            player.Runic = maxValue;
            player.Platinum = maxValue;
            player.Gold = maxValue;
            player.Silver = maxValue;
            player.Copper = maxValue;

            actualValue = gameManager._get_coin_weight(player);

            Console.WriteLine("Test {0} Status = {1}", MethodBase.GetCurrentMethod().Name, actualValue.ToString().Equals(expectedValue.ToString()) == true ? "Pass" : "Fail");
        }
    }
}
