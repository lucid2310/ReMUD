using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Tests
{
    public class TestConstants
    {
        public const string InputFiles = "..\\..\\..\\..\\DATs";

        public static string GetAbsolutePath()
        {
            return System.IO.Path.GetFullPath(InputFiles);
        }
    }
}
