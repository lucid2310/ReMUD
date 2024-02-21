using ReMUD.Game.Structures.Utilities;
using ReMUD.Game.Utilities;
using ReMUD.Server.Network;
using ReMUD.Server.Output;

namespace ReMUD.Server.Pages
{
    public class GamePage : BasePage
    {
        public GamePage(GameClient client) : base(client)
        {
        }

        public override void Display()
        {
            
        }

        public override void Load()
        {
            string gameMenu = CustomFileUtility.GetDisplay("MENUTEXT {", "} T Main Menu text");
            string gamePrompt = CustomFileUtility.GetDisplay("MENUPMPT {", "} T Main Menu text");

            Send(AnsiHandler.ClearScreenAndHomeCursor);

            Messages.Add(0, PrintFormatUtility.sprintf(gameMenu, "1.11p"));
            Messages.Add(1, gamePrompt);

            Send(Messages[_currentMessageIndex]);
            Send(Messages[_currentMessageIndex + 1]);
        }

        public override void Process(string command)
        {         
            if(command.ToLower() == "e")
            {

            }
        }
    }
}
