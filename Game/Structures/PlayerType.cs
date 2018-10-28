using ReMUD.Game.Managers;
using ReMUD.Game.Structures.SupportTypes;
using ReMUD.Game.Structures.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures
{
    // Conversion from VB to C#
    //            Long = Int
    //            Int = Short
    public struct PlayerType
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public char[] Username;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public char[] FirstName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 19)]
        public char[] LastName;
        public int NotExperience;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] SpellCasted;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] SpellValue;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public short[] SpellRoundsLeft;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] Title;
        public short Race;
        public short Class;
        public short Level;
        public PlayerStatType PrimaryStats;
        public short MaximumHitpoints;
        public short CurrentHitpoints;
        public short MaximumEncumbrance;
        public short CurrentEncumbrance;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public short[] Energy;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] unknown1;
        public short MagicRes;
        public short MagicRes2;
        public int MapNumber;
        public int RoomNum;
        public short Nothing2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] Unknown2;
        public short Nothing3;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Unknown3;
        public short Nothing4;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public int[] Item;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public short[] ItemUses;
        public int nothing5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public int[] Key;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public short[] KeyUses;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] unknown4;
        public int BillionsOfExperience;
        public int MillionsOfExperience;
        public short MaximumKnownSpells;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public short[] Spell;
        public short EvilPoints;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public int[] nothing7;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public int[] LastMap;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public int[] LastRoom;
        public short BriefVerboseFlag;
        public short BroadcastChannel;
        public byte TalkSpeed;
        public byte Statline;
        public short Offset_5F6;
        public short Perception;
        public short Stealth;
        public short MartialArts;
        public short Thievery;
        public short MaxMana;
        public short CurrentMana;
        public short SpellCasting;
        public short Traps;
        public short unknown6;
        public short Picklocks;
        public short Tracking;
        public short nothing9;
        public CurrencyType Currency;
        public int WeaponHand;
        public int nothing10;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public int[] WornItem;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public short[] WornItemUses;
        public short unknown8;
        public short LivesRemaining;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public short[] unknown9;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public short[] PartyMember;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public short[] unknownFiller;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] GangName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] unknown11;
        public short CPRemaining;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] SuicidePassword;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public short[] unknown12a;
        public byte bEDITED;
        public byte unknown12c;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public short[] unknown12d;
        public short EncumbrancePercent;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public short[] unknown12e;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public short[] AbilityId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public short[] AbilityValue;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public short[] unknown13a;
        public int CharLife;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public short[] unknown13;
        public byte Bitmask1;
        public byte Bitmask2;
        public byte TestFlag1;
        public byte TestFlag2;
        public short unknown14;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] unknown15;

        //<start>
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        //public char[] Username;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        //public char[] FirstName;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 19)]
        //public char[] LastName;
        //public int NotExperience;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        //public short[] SpellCasted;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        //public short[] SpellValue;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        //public short[] SpellRoundsLeft;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        //public char[] Title;
        //public short Race;
        //public short Class;
        //public short Level;
        //public PlayerStatType Stats;
        //public short MaximumHitpoints;
        //public short CurrentHitpoints;
        //public short MaximumEncumbrance;
        //public short CurrentEncumbrance;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        //public short[] Energy;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        //public short[] unknown1;
        //public short MagicRes;
        //public short MagicRes2;
        //public int MapNumber;
        //public int RoomNum;
        //public short Nothing2;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        //public short[] Unknown2;
        //public short Nothing3;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        //public byte[] Unknown3;
        //public short Nothing4;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        //public int[] Item;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        //public short[] ItemUses;
        //public int Offset_330;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        //public int[] Key;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        //public short[] KeyUses;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        //public int[] unknown4;
        //public int BillionsOfExperience;
        //public int MillionsOfExperience;
        //public short MaximumKnownSpells;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        //public short[] Spell;
        //public short EvilPoints;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        //public byte[] Offset_544;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        //public int[] Offset_54A;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        //public int[] LastMap;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        //public int[] LastRoom;
        //public short BriefVerboseFlag;
        //public short BroadcastChannel;
        //public byte TalkSpeed;
        //public byte Statline;
        //public short Offset_5F6;
        //public short Perception;
        //public short Stealth;
        //public short MartialArts;
        //public short Thievery;
        //public short MaxMana;
        //public short CurrentMana;
        //public short SpellCasting;
        //public short Traps;
        //public short Offset_608;
        //public short Picklocks;
        //public short Tracking;
        //public short nothing9;
        //public CurrencyType Currency;
        //public int WeaponHand;
        //public int nothing10;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        //public int[] WornItem;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        //public short[] WornItemUses;
        //public short Offset_6A4;
        //public short LivesRemaining;
        //public short Offset_6A8;
        //public ushort Offset_6AA;
        //public short Offset_6AC;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        //public short[] PartyMembers;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        //public short[] Offset_6B8;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        //public char[] GangName;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        //public byte[] Offset_6DC;
        //public short CPRemaining;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        //public char[] SuicidePassword;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        //public short[] Offset_6EC;
        //public byte bEDITED;
        //public byte Offset_6FD;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        //public short[] Offset_6FE;
        //public short EncumbrancePercent;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        //public short[] unknown12e;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        //public short[] AbilityId;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        //public short[] AbilityValue;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        //public short[] unknown13a;
        //public int CharLife;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        //public short[] Offset_7C4;
        //public byte Bitmask1;
        //public byte Bitmask2;
        //public byte TestFlag1;
        //public byte TestFlag2;
        //public short unknown14;
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        //public int[] unknown15;
        //<stop>

        public byte[] Serialize()
        {
            return BtrieveUtility.Serialize<PlayerType>(this);
        }

        public PlayerType Initialize()
        {
            return BtrieveUtility.Deserialize<PlayerType>(new byte[Marshal.SizeOf(this)]);
        }

        public void SetFirstName(string name)
        {
            FirstName = new char[11];
            FirstName = name.PadRight(FirstName.Length, '\0').ToArray();
        }

        public void SetUserName(string username)
        {
            Username = new char[30];
            Username = username.PadRight(Username.Length, '\0').ToArray();
        }

        public void SetTitle(string title)
        {
            Title = new char[20];
            Title = title.PadRight(Title.Length, '\0').ToArray();
        }

        public string GetUsername()
        {
            return BtrieveUtility.ConvertToString(Username);
        }

        //public static void PrintStats(PlayerType player)
        //{
        //    List<string> outputText = new List<string>();
        //    string tmpValue = string.Empty;
        //    string tmpName = string.Empty;

        //    FieldInfo[] fi = typeof(PlayerType).GetFields(BindingFlags.Public | BindingFlags.Instance);

        //    foreach (FieldInfo info in fi)
        //    {
        //        string tmpType = info.FieldType.Name;
        //        object tmpData = info.GetValue(player);

        //        switch (tmpType)
        //        {
        //            case "Char[]":                        
        //                tmpValue = BtrieveUtility.ConvertToString((char[])tmpData);
        //                break;
        //            case "Int32[]":
        //                tmpValue = BtrieveUtility.ConvertIntArrayToStringArray((int[])tmpData);
        //                break;
        //            case "Int16[]":
        //                tmpValue = BtrieveUtility.ConvertIntArrayToStringArray((short[])tmpData);
        //                break;
        //            case "Byte[]":
        //                tmpValue = BtrieveUtility.ConvertIntArrayToStringArray((byte[])tmpData);
        //                break;
        //            default:
        //                tmpValue = info.GetValue(player).ToString();
        //                break;
        //        }

        //        LogManager.Log("{0}, {1}", info.Name, tmpValue);
        //    }
        //}
    }
}
