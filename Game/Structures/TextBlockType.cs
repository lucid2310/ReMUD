using ReMUD.Game.Structures.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Structures
{
    public struct TextBlockType
    {
        public short PartNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        public byte[] LeadIn;
        public int Number;
        public int LinkTo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2000)]
        public char[] Data;

        public string DecryptTextblock()
        {
            Encoding cp437 = Encoding.GetEncoding(437);

            List<byte> sDecrypted = new List<byte>();
    
            char sChar = '0';

            for (int x = 0; x < Data.Length; x++)
            {
                sChar = Data[x];

                if (sChar >= 32)
                {
                    if ((int)sChar > 0xFF)
                    {
                        sDecrypted.Add((byte)(BtrieveUtility.GetDecode((int)sChar) - 32));
                    }
                    else
                    {
                        sDecrypted.Add((byte)(sChar - 32));
                    }
                }
            }

            return Encoding.ASCII.GetString(sDecrypted.ToArray()).Replace("'", "''");
        }
    }
}
