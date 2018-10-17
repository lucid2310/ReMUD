using ReMUD.Game.Structures.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures
{
    public struct MessageType
    {
        public int Number;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 82)]
        public char[] MessageLine1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 82)]
        public char[] MessageLine2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
        public char[] MessageLine3;

        public string GetMessage(int line)
        {
            switch(line)
            {
                case 1:
                    return BtrieveUtility.ConvertToString(MessageLine1);
                case 2:
                    return BtrieveUtility.ConvertToString(MessageLine2);
                case 3:
                    return BtrieveUtility.ConvertToString(MessageLine3);
                default:
                    return BtrieveUtility.ConvertToString(MessageLine1);
            }
        }
    }
}
