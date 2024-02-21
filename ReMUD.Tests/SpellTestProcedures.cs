using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReMUD.Game.Managers;
using ReMUD.Game.Structures;

namespace ReMUD.Tests
{
    [TestClass]
    public class SpellTestProcedures
    {
        private SpellManager SpellContentManager = new SpellManager();

        [TestInitialize]
        public void Setup()
        {
            SpellContentManager.Initialize(TestConstants.GetAbsolutePath());
        }

        /// <summary>
        /// This test case will ensure the Spell structure is correct.
        /// </summary>
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

        /// <summary>
        /// This test case ensures the structure is the correct number of bytes.
        /// </summary>
        [TestMethod]
        public void SpellType_TC02()
        {
            SpellType? spellType = SpellContentManager.Select(1);

            byte[] serialiedData = spellType.Value.Serialized();

            Assert.AreEqual(260, serialiedData.Length);
        }

        /// <summary>
        /// This test case is a performance test.
        /// </summary>
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

            LogManager.Log("Finished in {0} msec.", performanceTime.ElapsedMilliseconds);
        }

        /// <summary>
        /// This test case is a performance test.
        /// </summary>
        [TestMethod]
        public void SpellType_TC04()
        {
            SpellType spellType = SpellContentManager.Select(1);

            SpellType spellTypeA = spellType;

            spellTypeA.Difficulty = 16;
     
            ushort status = SpellContentManager.Save(spellTypeA);

            Assert.AreEqual(Game.Btrieve.BtrieveTypes.BtrieveStatus.COMPLETE_SUCCESSFULLY, status);

            SpellType spellTypeB = SpellContentManager.Select(1);
        }

        public void AssertValue(object valueA, object valueB)
        {
            LogManager.Log("Assert value {0} is set to {1}", valueA, valueB);
            Assert.AreEqual(valueA, valueB);
        }

        [TestCleanup]
        public void Cleanup()
        {
            SpellContentManager.Close();
        }
    }
}
