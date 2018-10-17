using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.Game.Managers
{
    public static class LogManager
    {
        public static void Log(string message, params object[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}
