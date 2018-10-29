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

            player.Currency.Runic = 1;
            player.Currency.Platinum = 1;
            player.Currency.Gold = 1;
            player.Currency.Silver = 1;
            player.Currency.Copper = 1;

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

            player.Currency.Runic = maxValue;
            player.Currency.Platinum = maxValue;
            player.Currency.Gold = maxValue;
            player.Currency.Silver = maxValue;
            player.Currency.Copper = maxValue;

            actualValue = gameManager._get_user_currency(player);

            Console.WriteLine("Test {0} Status = {1}", MethodBase.GetCurrentMethod().Name, actualValue.ToString().Equals(expectedValue.ToString()) == true ? "Pass" : "Fail");
        }

        public static void GetCoinWeight_TC01()
        {
            // all currency normalized to copper.
            object expectedValue = 165;
            object actualValue = 0;

            GameManager gameManager = new GameManager();

            PlayerType player = PlayerType.Initialize();

            int maxValue = 100;

            player.Currency.Runic = maxValue;
            player.Currency.Platinum = maxValue;
            player.Currency.Gold = maxValue;
            player.Currency.Silver = maxValue;
            player.Currency.Copper = maxValue;

            actualValue = gameManager._get_coin_weight(player);

            Console.WriteLine("Test {0} Status = {1}", MethodBase.GetCurrentMethod().Name, actualValue.ToString().Equals(expectedValue.ToString()) == true ? "Pass" : "Fail");
        }
    }
}
