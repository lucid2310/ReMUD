using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReMUD.Game.Managers;
using ReMUD.Game.Structures;
using ReMUD.Game.Structures.Utilities;

namespace ReMUD.Tests
{
    [TestClass]
    public class ShopTestProcedures
    {
        private ShopManager _shopContentManager = new ShopManager();

        [TestInitialize]
        public void Setup()
        {
            _shopContentManager.Initialize(TestConstants.GetAbsolutePath());
        }

        [TestMethod]
        public void Shop_TC01()
        {
            ShopType shopType = _shopContentManager.Select(3);

            Assert.AreEqual(3, shopType.Number);
            Assert.AreEqual("General Store", BtrieveUtility.ConvertToString(shopType.Name));
            Assert.AreEqual(10, shopType.ShopIndicator);
            Assert.AreEqual(175, shopType.ShopItemNumber[0]);
        }
    }
}
