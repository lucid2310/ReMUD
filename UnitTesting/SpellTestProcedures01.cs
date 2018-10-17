using ContentFramework.ContentStructures;
using MajormudConversion.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMajormudFunctions
{
    [TestClass]
    public class SpellTestProcedures01
    {
        private SpellManager SpellContentManager = new SpellManager();

        [TestInitialize]
        public void Setup()
        {
            SpellContentManager.Initialize(@"C:\Users\laked\source\repos\MajormudConversion\DATs");
        }

        [TestMethod]
        public void SpellType_TC01()
        {
            SpellType? spellType = SpellContentManager.Select(1);

            AssertValue(true, spellType.HasValue);
            AssertValue("magic missile", spellType.Value.GetName());
            AssertValue((short)1, spellType.Value.Number);
            AssertValue("This spell shoots a shimmering dart of pure mana", spellType.Value.GetDescriptionA());
            AssertValue("at the target, causing minor damage.", spellType.Value.GetDescriptionB());
            AssertValue((int)1, spellType.Value.CastMsgA);
            AssertValue((int)3242, spellType.Value.CastMsgB);
            AssertValue((byte)6, spellType.Value.LevelCap);
            AssertValue((byte)32, spellType.Value.MsgStyle);

            short[] expectedAbilityB = new short[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            short[] expectedAbilityA = new short[] { 17, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for(int i = 0; i < expectedAbilityA.Length; i++)
            {
                AssertValue(expectedAbilityA[i], spellType.Value.AbilityA[i]);
                AssertValue(expectedAbilityB[i], spellType.Value.AbilityB[i]);
            }

            AssertValue((short)1000, spellType.Value.Energy);
            AssertValue((short)1, spellType.Value.Level);
            AssertValue((short)4, spellType.Value.BaseMinimum);
            AssertValue((short)12, spellType.Value.BaseMaximum);
            AssertValue((short)0, spellType.Value.SpellAttackType);
            AssertValue((short)0, spellType.Value.TypeOfResists);
            AssertValue((short)15, spellType.Value.Difficulty);
            AssertValue((short)0, spellType.Value.Duration);
            AssertValue((short)8, spellType.Value.Target);
            AssertValue((short)4, spellType.Value.TypeOfAttack);
            AssertValue((short)0, spellType.Value.ResistAbility);
            AssertValue((short)1, spellType.Value.MageType);
            AssertValue((short)1, spellType.Value.MageLevel);
            AssertValue((short)1, spellType.Value.Mana);

            AssertValue((byte)1, spellType.Value.MaxIncrease);
            AssertValue((byte)0, spellType.Value.MinIncrease);
            AssertValue((byte)0, spellType.Value.LVLSMaxIncr);
            AssertValue((byte)0, spellType.Value.LVLSMinIncr);
            AssertValue((byte)0, spellType.Value.DurIncrease);
            AssertValue((byte)0, spellType.Value.LVLSDurIncr);
            AssertValue("mmis", spellType.Value.GetShortName());
        }

        [TestMethod]
        public void SpellType_TC02()
        {
            SpellType? spellType = SpellContentManager.Select(1);

            byte[] serialiedData = spellType.Value.Serialized();

            Assert.AreEqual(260, serialiedData.Length);
        }

        [TestMethod]
        public void SpellType_TC03()
        {
            Stopwatch performanceTime = new Stopwatch();

            performanceTime.Start();

            for (int i = 0; i < 10000; i++)
            {
                SpellType? spellType = SpellContentManager.Select(1);
            }

            performanceTime.Stop();

            Console.WriteLine("Finished in {0} msec.", performanceTime.ElapsedMilliseconds);
        }

        public void AssertValue(object valueA, object valueB)
        {
            Console.WriteLine("Assert value {0} is set to {1}", valueA, valueB);
            Assert.AreEqual(valueA, valueB);
        }

        [TestCleanup]
        public void Cleanup()
        {

        }
    }
}
