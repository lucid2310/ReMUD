using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ReMUD.Game.Structures.Utilities
{
    public static class PrintFormatUtility
    {
        public static string sprintf(string input, params object[] inpVars)
        {
            int i = -1;

            string tmpOutput = string.Empty;

            input = input.Replace("{", "_^_");
            input = input.Replace("}", "^_^");

            input = Regex.Replace(input, "%.", m => ("{" + ++i + "}"));

            tmpOutput = string.Format(input, inpVars);

            tmpOutput = tmpOutput.Replace("_^_", "{");
            tmpOutput = tmpOutput.Replace("^_^", "}");

            return tmpOutput;
        }
    }
}
