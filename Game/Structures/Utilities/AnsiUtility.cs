using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReMUD.Game.Structures.Utilities
{
    public static class AnsiUtility
    {
        public static Dictionary<int, byte> Ascii;

        static AnsiUtility()
        {
            Ascii = new Dictionary<int, byte>
            {
                {'─', 196},
                {'Ç', 128},
                {'ü', 129},
                {'é', 130},
                {'│', 179},
                {'┤', 180},
                {'«', 174},
                {'»', 175},
                {'┌', 218},
                {'┐', 191},
                {'├', 195},
                {'└', 192},
                {'┘', 217},
                {'◄', 17},
                {'⌐', 169},
                {'┴', 193}
            };

            for (byte i = 0; i < 0x80; i++)
            {
                Ascii.Add(i, i);
            }
        }

        public static byte[] GetBytes(string inputString)
        {
            byte[] outputData = new byte[inputString.Length];

            for (int i = 0; i < inputString.Length; i++)
            {
                outputData[i] = Ascii[(int)inputString[i]];
            }

            return outputData;
        }
    }
}
