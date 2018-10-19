using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures.SupportTypes
{
    public struct InventoryItemType
    {
        public int Number;
        public short Uses;

        public InventoryItemType(int number, short uses)
        {
            Number = number;
            Uses = uses;
        }
    }
}
