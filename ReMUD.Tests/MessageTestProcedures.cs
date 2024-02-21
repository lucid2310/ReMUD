using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReMUD.Game.Managers;
using ReMUD.Game.Structures;

namespace ReMUD.Tests
{
    [TestClass]
    public class MessageTestProcedures
    {
        private MessageManager MessageContentManager = new MessageManager();
      
        [TestInitialize]
        public void Setup()
        {
            MessageContentManager.Initialize(TestConstants.GetAbsolutePath());
        }

        [TestMethod]
        public void Messages_01()
        {
            MessageType messageType = MessageContentManager.Select(2);

            Assert.AreEqual("You cast %s!", messageType.GetMessage(1));
            Assert.AreEqual("%s casts %s!", messageType.GetMessage(2));
            Assert.AreEqual("%s casts %s!", messageType.GetMessage(3));
        }
    }
}
