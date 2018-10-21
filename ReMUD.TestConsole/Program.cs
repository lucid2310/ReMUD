using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReMUD.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PlayerTestProcedures playerTestProcedures = new PlayerTestProcedures();

                playerTestProcedures.Setup();
                playerTestProcedures.PlayerStructure_TC03();
                playerTestProcedures.Cleanup();

                Console.Read();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
