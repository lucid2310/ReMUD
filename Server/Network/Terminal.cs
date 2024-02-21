using System.Net.Sockets;


namespace ReMUD.Server.Network
{
    public class Terminal
    {
        public int RowIndex = 0;
        public int ColumnIndex = 0;
        private Socket _socket;

        public Terminal(Socket socket)
        {
            RowIndex = 0;
            ColumnIndex = 0;

            _socket = socket;
        }
    }
}
