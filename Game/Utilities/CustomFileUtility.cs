using ReMUD.Game.Structures.SupportTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReMUD.Game.Utilities
{
    public static class CustomFileUtility
    {
        public static string GetDisplay(string fromText, string toText)
        {
            string fileContents = File.ReadAllText(@"C:\WGSERV\wcctext.msg", Encoding.GetEncoding(437));

            List<string> characterCreationMenu = new List<string>();
            Dictionary<string, TextMsgTypes> menus = new Dictionary<string, TextMsgTypes>();

            int startIndex = 0;
            int stopIndex = 0;

            string outputData = string.Empty;
            string keyName = string.Empty;
            int t = 0;

            startIndex = fileContents.IndexOf(fromText);
            stopIndex = fileContents.IndexOf(toText, startIndex);

            int fileLength = fileContents.Length;

            outputData = fileContents.Substring(startIndex, (stopIndex - startIndex));

            outputData = outputData.Replace(fromText, "");
            outputData = outputData.Replace(toText, "");

            return outputData;
        }
    }
}
