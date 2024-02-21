using ReMUD.Module.Managers;
using ReMUD.Server.Network;
using ReMUD.Server.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReMUD.Server.Pages
{
    public class LoginPage : BasePage
    {
        private string _currentUsername = string.Empty;
        private string _currentPassword = string.Empty;

        public LoginPage(GameClient client) : base(client)
        {
            
        }

        public override void Load()
        {
            NextPage = PageStates.Menu;

            Send(AnsiHandler.ClearScreenAndHomeCursor);
            string serverName = AnsiHandler.ClearToSOL + AnsiHandler.SetTextAttributes(AnsiAttribute.Bold, AnsiForegroundColor.Green, string.Format("ReMUD Server v{0}", GameServer.Version));
            string date = AnsiHandler.ClearToSOL + AnsiHandler.SetTextAttributes(AnsiAttribute.Bold, AnsiForegroundColor.Green, DateTime.Now.ToShortDateString());

            string systemPrefix = string.Format($"{AnsiHandler.SetTextAttributes(AnsiAttribute.Bold, AnsiForegroundColor.Magenta, "            WELCOME!")}{AnsiHandler.SetForegroundColor(AnsiForegroundColor.Green)}\n{serverName}\n{date}\n");

            string systemUserEntry = $"{AnsiHandler.ClearToSOL}If you already have a User-ID on this\n{AnsiHandler.ClearToSOL}system," +
                                                  $" type it in and press ENTER.\n{AnsiHandler.ClearToSOL}Otherwise type \"{AnsiHandler.SetForegroundColor(AnsiForegroundColor.Cyan)}new{AnsiHandler.SetForegroundColor(AnsiForegroundColor.Green)}\": ";
            Send(systemPrefix);

            Messages.Add(0, AnsiHandler.MoveCursorToNewLine() + systemUserEntry);
           // Messages.Add(1, AnsiHandler.MoveCursorToNewLine() + "Username: ");
            Messages.Add(1, AnsiHandler.MoveCursorToNewLine() + $"\n{AnsiHandler.ClearToSOL}Enter your password: ");
            Messages.Add(2, AnsiHandler.MoveCursorToNewLine() + $"\n\n{AnsiHandler.ClearToSOL}{AnsiHandler.SetForegroundColor(AnsiForegroundColor.Yellow)}Welcome to the ReMUD Server.");

            //Send(Messages[_currentMessageIndex++]);
            Send(Messages[_currentMessageIndex]);
        }

        public override void Display()
        {
            // Send(Messages[_currentMessageIndex]);
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

                        if (UserManager.UserExists(command) == true)
                        {
                            _currentUsername = command;
                            _currentMessageIndex++;
                            Send(Messages[_currentMessageIndex]);
                            EnableMask = true;

                        }
                        else
                        {
                            _currentUsername = string.Empty;

                            Send($"{AnsiHandler.SetForegroundColor(AnsiForegroundColor.Magenta)}\n\n{AnsiHandler.ClearToSOL}Sorry, no such User-ID exists in our\n{AnsiHandler.ClearToSOL}database. Maybe you mistyped it?\n{AnsiHandler.SetForegroundColor(AnsiForegroundColor.Green)}");

                            Send(Messages[_currentMessageIndex]);
                        }

                        break;
                    case 1:

                        if (UserManager.UserPassword(_currentUsername, command) == true)
                        {
                            _currentPassword = command;
                            _currentMessageIndex++;
                            Send(Messages[_currentMessageIndex]);

                            MoveToNext = true;
                        }
                        else
                        {
                            _currentPassword = string.Empty;
                            Send($"{AnsiHandler.SetForegroundColor(AnsiForegroundColor.Magenta)}Sorry, the password you have given is\n{AnsiHandler.ClearToSOL}incorrect. Maybe you mistyped it?\n{AnsiHandler.SetForegroundColor(AnsiForegroundColor.Green)}");
                            Send(Messages[_currentMessageIndex]);
                        }

                        break;
                }
            }
        }
    }
}
