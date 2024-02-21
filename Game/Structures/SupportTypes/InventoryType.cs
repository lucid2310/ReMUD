using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures.SupportTypes
{
    public struct InventoryType
    {
        public const int ITEM_TYPE = 0;
        public const int KEY_TYPE = 1;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public int[] Item;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public short[] ItemUses;
        public int nothing5;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public int[] Key;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public short[] KeyUses;

        public InventoryItemType GetItemInformation(int index, int type)
        {
            switch (type)
            {
                case ITEM_TYPE:
                    return new InventoryItemType(Item[index], ItemUses[index]);
                case KEY_TYPE:
                    return new InventoryItemType(Key[index], KeyUses[index]);
            }

            return new InventoryItemType();
        }

        public void SetItemInformation(int index, int type, int id, short uses)
        {
           
            switch (type)
            {
                case ITEM_TYPE:
                    Item[index] = id;
                    ItemUses[index] = uses;
                    break;
                case KEY_TYPE:
                    Key[index] = id;
                    KeyUses[index] = uses;
                    break;
            }
        }
    }
}
