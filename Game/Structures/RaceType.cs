﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures
{
    public struct RaceType
    {
        //<start>
        public short Number;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 29)]
        public char[] Name;
        public byte nothing1;
        public short MinInt;
        public short MinWil;
        public short MinStr;
        public short MinHea;
        public short MinAgl;
        public short MinChm;
        public short HPBonus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Padding01;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] AbilityId;
        public short CP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] AbilityValue;
        public int nothing3;
        public short nothing4;
        public short ExpChart;
        public short nothing5;
        public short MaxInt;
        public short MaxWil;
        public short MaxStr;
        public short MaxHea;
        public short MaxAgl;
        public short MaxChm;
        public int Nothing6;
        public int nothing7;
        public int nothing8;
        //<stop>

        public string GetName()
        {
            return Utilities.BtrieveUtility.ConvertToString(Name);
        }
    }
}
