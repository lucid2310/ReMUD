using System;
using MajormudConversion.Managers;
using MajormudConversion.Structures;
using MajormudConversion.Structures.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMajormudFunctions
{
    [TestClass]
    public class ShopTestProcedures
    {
        private ShopManager _shopContentManager = new ShopManager();

        [TestInitialize]
        public void Setup()
        {
            _shopContentManager.Initialize(@"E:\TrueMUD\DATs");
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
