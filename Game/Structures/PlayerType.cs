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

    public struct PlayerType
    {
        //<start>
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
        public short Intellect;
        public short WillPower;
        public short Strength;
        public short Health;
        public short Agility;
        public short Charm;
        public short MaxIntellect;
        public short MaxWillPower;
        public short MaxStrength;
        public short MaxHealth;
        public short MaxAgility;
        public short MaxCharm;
        public short MaximumHitpoints;
        public short CurrentHitpoints;
        public short MaximumEncumbrance;
        public short CurrentEncumbrance;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public short[] Energy;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] OffSet_xBC_xBE;
        public short MagicRes;
        public short MagicRes2;
        public int MapNumber;
        public int RoomNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] OffSet_xCC_xD7;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public int[] Item;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public short[] ItemUses;
        public int OffSet_x330;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public int[] Key;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public short[] KeyUses;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] OffSet_x460_x46F;
        public int BillionsOfExperience;
        public int MillionsOfExperience;
        public short MaximumKnownSpells;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public short[] Spell;
        public short EvilPoints;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] OffSet_x544_54F;
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
        public short BaseTraps;
        public short Picklocks;
        public short Tracking;
        public short nothing9;
        public int Runic;
        public int Platinum;
        public int Gold;
        public int Silver;
        public int Copper;
        public int WeaponHand;
        public int OffSet_x628;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public int[] WornItem;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public short[] WornItemUses;
        public short OffSet_x6A4;
        public short LivesRemaining;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] OffSet_x6A8_x6AD;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public short[] PartyMember;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] OffSet_x6B8_x6BA;
        public byte Delay;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] OffSet_x6BC_x6C7;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] GangName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] OffSet_x6DC_x6E1;
        public short CPRemaining;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] SuicidePassword;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] OffSet_x6EC_x6FB;
        public byte EditFlag;
        public byte OffSet_x6FD;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] OffSet_x6FE_x707;
        public short EncumbrancePercent;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] OffSet_x70A_x739;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public short[] AbilityId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public short[] AbilityValue;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        public byte[] OffSet_x7B2_x7BF;
        public int CharacterLife;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] OffSet_x7C4_x7D5;
        public byte Bitmask1;
        public byte Bitmask2;
        public byte TestFlag1;
        public byte TestFlag2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] OffSet_x7DA_x7EB;
        //<stop>

        public byte[] Serialize()
        {
            return BtrieveUtility.Serialize<PlayerType>(this);
        }

        public static PlayerType Initialize()
        {
            PlayerType tmpPlayer = new PlayerType();

            return BtrieveUtility.Deserialize<PlayerType>(new byte[Marshal.SizeOf(tmpPlayer)]);
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

        public static bool Validate(PlayerType player)
        {
            if(player.Username == null)
            {
                return false;
            }

            if (player.Username[0] == 0)
            {
                return false;
            }

            if(player.FirstName == null)
            {
                return false;
            }

            if(player.FirstName[0] == 0)
            {
                return false;
            }

            return true;
        }
    }
}
