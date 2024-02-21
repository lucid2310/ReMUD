using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ReMUD.Server.Managers
{
    public class SocketPacket
    {
        public Socket CurrentSocket;
        public byte[] DataBuffer = new byte[1];
    }
}
