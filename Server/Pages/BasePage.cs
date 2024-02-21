using ReMUD.Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReMUD.Server.Pages
{
    public abstract class BasePage
    {
        protected GameClient _client;
        protected Dictionary<int, string> Messages = new Dictionary<int, string>();
        protected int _currentMessageIndex = 0;
        public bool MoveToNext = false;
        public PageStates NextPage = PageStates.Login;
        public bool EnableMask = false;
        public byte[] MaskCharacter = new byte[] { 0x2A };

        public BasePage(GameClient client)
        {
            _client = client;
        }

        public abstract void Load();
        public abstract void Process(string command);
        public abstract void Display();

        public void Send(string input)
        {
            _client.Send(Encoding.ASCII.GetBytes(input));
        }
    }
}
