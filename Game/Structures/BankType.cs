using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures
{
    public struct BankType
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public char[] BBSName;
        public short Ignore01;
        public int ShopNumber;
        public int Cash;
    }
}
