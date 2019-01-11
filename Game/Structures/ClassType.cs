using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures
{
    public struct ClassType
    {
        //<start>
        public short Number;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public char[] Name;
        public short MinHP;
        public short MaxHP;
        public short Exp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public short[] Ignore_One;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] AbilityId;
        public short MagicType;
        public short MagicLevel;
        public short WeaponType;
        public short ArmorType;
        public short CombatRating;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] AbilityValue;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public short[] Ignore_Two;
        public int TitleText;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
        public short[] PaddingThree;
        //<stop>
    }
}
