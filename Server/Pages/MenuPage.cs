using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ReMUD.Server.Network;
using ReMUD.Server.Output;

namespace ReMUD.Server.Pages
{
    public class MenuPage : BasePage
    {      
        public MenuPage(GameClient client) : base(client)
        {
            NextPage = PageStates.Game;
        }

        public override void Load()
        {
            string[] fileContents = File.ReadAllLines(@"C:\WGSERV\WCCTEXT.MSG");

            for(int i = 0; i < fileContents.Length; i++)
            {
                if(fileContents[i].Contains("MENUTEXT") == true)
                {

                }
            }

            Send(AnsiHandler.ClearScreenAndHomeCursor);

            Messages.Add(0, AnsiHandler.MoveCursorToNewLine() + "Main Menu" + AnsiHandler.MoveCursorToNewLine() +
                            AnsiHandler.MoveCursorToNewLine() + "M: Majormud" + AnsiHandler.MoveCursorToNewLine() + "X: Exit");

            Send(Messages[_currentMessageIndex]);
        }

        public override void Display()
        {
           //
        }

        public override void Process(string command)
        {
            if (command == "")
            {
                Send(Messages[_currentMessageIndex]);
            }
            else
            {
                switch (_currentMessageIndex)
                {

                    case 0:
                    
                        if(command.ToLower() == "x")
                        {

                        }

                        if(command.ToLower() == "m")
                        {
                            NextPage = PageStates.Game;
                            MoveToNext = true;
                        }
              
                        break;
                }
            }
        }
    }
}
