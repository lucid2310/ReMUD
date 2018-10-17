using System;
using System.IO;
using MajormudConversion.Managers;
using MajormudConversion.Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMajormudFunctions
{
    [TestClass]
    public class PlayerTestProcedures01
    {
        [TestInitialize]
        public void Setup()
        {
          // PlayerManager.Load(@"C:\Users\laked\source\repos\MajormudConversion\DATs");
           // PlayerManager.Load(@"C:\WGSERV");
        }

        [TestMethod]
        public void Player_TC01()
        {
          //  PlayerType playerType = PlayerManager.GetPlayer("PlayerType").Record;
           // PlayerType.PrintStats(playerType);

            //PlayerEntity playerType = PlayerManager.GetPlayer("Sysop");

            //File.WriteAllBytes(@"C:\temp\pre_player_dump.bin", playerType.Record.Serialize());
        }

        [TestMethod]
        public void Player_TC02()
        {
            //PlayerEntity playerType = PlayerManager.GetPlayer("Sysop");

            //File.WriteAllBytes(@"C:\temp\post_player_dump.bin", playerType.Record.Serialize());
        }

        [TestCleanup]
        public void Cleanup()
        {

        }
    }
}
