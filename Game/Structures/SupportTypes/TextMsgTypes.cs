using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReMUD.Game.Structures.SupportTypes
{
    public struct TextMsgTypes
    {
        public int StartIndex;
        public int StopIndex;
        public string TextMsg;

        public TextMsgTypes(int startIndex, int stopIndex, string inputText)
        {
            StartIndex = startIndex + 1;
            StopIndex = stopIndex - 1;
   
            TextMsg = inputText.Substring(StartIndex, StopIndex - StartIndex);

            Console.Write(TextMsg);
        }
    }
}
