using ReMUD.Game.Structures.Utilities;
using System.Runtime.InteropServices;


namespace ReMUD.Game.Structures
{
    public struct SpellType
    {
        //<start>
        public short Number;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public char[] Name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
        public char[] DescriptionA;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
        public char[] DescriptionB;
        public short Padding00;
        public int CastMsgA;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public short[] Padding01;
        public byte LevelCap;
        public byte Padding02;
        public byte MsgStyle;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Padding03;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] AbilityValue;
        public short Energy;
        public short Level;
        public short BaseMinimum;
        public short BaseMaximum;
        public short SpellAttackType;
        public short TypeOfResists;
        public short Difficulty;
        public short Padding04;
        public short Target;
        public short Duration;
        public short TypeOfAttack;
        public short Padding05;
        public short ResistAbility;
        public short MageType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] AbilityId;
        public int CastMsgB;
        public short Mana;
        public byte MaxIncrease;
        public byte LVLSMaxIncr;
        public short MageLevel;
        public byte MinIncrease;
        public byte LVLSMinIncr;
        public byte DurIncrease;
        public byte LVLSDurIncr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] ShortName;
        public int Padding06;
        //<stop>

        public string GetName()
        {
            return BtrieveUtility.ConvertToString(Name);
        }

        public string GetDescriptionA()
        {
            return BtrieveUtility.ConvertToString(DescriptionA);
        }

        public string GetDescriptionB()
        {
            return BtrieveUtility.ConvertToString(DescriptionB);
        }

        public string GetShortName()
        {
            return BtrieveUtility.ConvertToString(ShortName);
        }

        public byte[] Serialized()
        {
            return BtrieveUtility.Serialize<SpellType>(this);
        }

        public static bool Validate(SpellType spell)
        {
            if(spell.Number == 0)
            {
                return false;
            }

            if (spell.Name == null)
            {
                return false;
            }

            if (spell.Name[0] == 0)
            {
                return false;
            }

            

            return true;
        }
    }
}

