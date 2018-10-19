using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReMUD.Game.Managers;
using ReMUD.Game.Structures;
using ReMUD.Game.Structures.SupportTypes;

namespace ReMUD.Tests
{
    [TestClass]
    public class PlayerTestProcedures
    {
        private PlayerManager ContentManager = new PlayerManager();

        [TestInitialize]
        public void Setup()
        {
            //ContentManager.Initialize(TestConstants.GetAbsolutePath());

            ContentManager.Initialize(@"C:\WGSERV");
        }

        [TestMethod]
        public void PlayerStructure_LiveServer()
        {
            PlayerType playerType = ContentManager.Select("Sysop");

            
        }

        [TestMethod]
        public void PlayerStructure_TC01()
        {
            PlayerType playerType = ContentManager.Select("test_player");

            //playerType.Stat.Agility = 10;
            //playerType.Stat.Charm = 11;
            //playerType.Stat.Health = 12;
            //playerType.Stat.Intellect = 13;
            //playerType.Stat.Strength = 14;
            //playerType.Stat.WillPower = 15;

            //playerType.Stat.MaxAgility = 20;
            //playerType.Stat.MaxCharm = 21;
            //playerType.Stat.MaxHealth = 22;
            //playerType.Stat.MaxIntellect = 23;
            //playerType.Stat.MaxStrength = 24;
            //playerType.Stat.MaxWillPower = 25;

            //playerType.HealthVitals.Current = 1000;
            //playerType.HealthVitals.Maximum = 2000;

            //for (int i = 0; i < playerType.Inventory.Item.Length; i++)
            //{
            //    playerType.Inventory.SetItemInformation(i, InventoryType.ITEM_TYPE, 9, -1);
            //}

            //for (int i = 0; i < playerType.Inventory.Key.Length; i++)
            //{
            //    playerType.Inventory.SetItemInformation(i, InventoryType.KEY_TYPE, 172, 10);
            //}

            ContentManager.Save(playerType);
        }

        [TestCleanup]
        public void Cleanup()
        {
            ContentManager.Close();
        }
    }
}
