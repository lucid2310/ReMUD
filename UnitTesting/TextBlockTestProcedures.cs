using System;
using System.IO;
using System.Text;
using MajormudConversion.Managers;
using MajormudConversion.Structures;
using MajormudConversion.Structures.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestMajormudFunctions
{
    [TestClass]
    public class TextBlockTestProcedures
    {
        public TextBlockManager TextBlockContentManager = new TextBlockManager();

        [TestInitialize]
        public void LoadContent()
        {
            TextBlockContentManager.Initialize(@"C:\Users\laked\source\repos\MajormudConversion\DATs");
        }

        [TestMethod]
        public void TextBlock01()
        {
          
            TextBlockType textBlock = TextBlockContentManager.Select(5);

            string actualText = textBlock.DecryptTextblock();

            Assert.AreEqual("boat:7\npassage:7\nskiff:7\ncharge:7\n", actualText);
            Assert.AreEqual(5, textBlock.Number);
            Assert.AreEqual(0, textBlock.PartNum);
            Assert.AreEqual(6, textBlock.LinkTo);
        }

        [TestMethod]
        public void TextBlock02()
        {
            TextBlockType textBlock = TextBlockContentManager.Select(327);

            Console.Write(textBlock.DecryptTextblock());

            Assert.AreEqual(327, textBlock.Number);
            Assert.AreEqual(0, textBlock.PartNum);
            Assert.AreEqual(0, textBlock.LinkTo);
        }
    }
}
