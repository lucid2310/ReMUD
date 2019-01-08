using ReMUD.Game;
using ReMUD.Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace ReMUD.Server.Network
{
    public class GameServer
    { 
        private Socket _mainSocket;
        private const int MAX_CLIENTS = 255;
        private const int MAX_BACKLOG = 5;

        private Dictionary<string, GameClient> _workerSocket = new Dictionary<string, GameClient>();
        private GameManager _gameManager = new GameManager();
        private int _port { get; set; }
        private string _directory { get; set; }
        private string _serverName { get; set; }

        public const string Version = "1.0";

        public GameServer(int port, string serverName, string directory)
        {
            _port = port;
            _directory = directory;
            _serverName = serverName;
        }

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(uint destIP, uint srcIP, byte[] macAddress, ref uint macAddressLength);

        public static byte[] GetMacAddress(IPAddress address)
        {
            byte[] mac = new byte[6];
            uint len = (uint)mac.Length;
            byte[] addressBytes = address.GetAddressBytes();
            uint dest = ((uint)addressBytes[3] << 24)
              + ((uint)addressBytes[2] << 16)
              + ((uint)addressBytes[1] << 8)
              + ((uint)addressBytes[0]);
            if (SendARP(dest, 0, mac, ref len) != 0)
            {
                throw new Exception("The ARP request failed.");
            }
            return mac;
        }

        public void Initialize()
        {
            Console.WriteLine("Initializing {0} Server.", _serverName);

           // _gameManager._init__wccmmud(_directory);

            // Create the listening socket...
            _mainSocket = new Socket(AddressFamily.InterNetwork,
                                      SocketType.Stream,
                                      ProtocolType.Tcp);
            IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, _port);
            // Bind to local IP Address...
            _mainSocket.Bind(ipLocal);
            // Start listening...
            _mainSocket.Listen(MAX_BACKLOG);
            // Create the call back for any client connections...
            _mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
        }

        public int DisconnectSession(string id)
        {
            _workerSocket.Remove(id);

            return 0;
        }

        // This is the call back function, which will be invoked when a client is connected
        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                // Here we complete/end the BeginAccept() asynchronous call
                // by calling EndAccept() - which returns the reference to
                // a new Socket object
                GameClient newSession = new GameClient(_mainSocket.EndAccept(asyn), _gameManager, DisconnectSession);
              
                // Let the worker Socket do the further processing for the 
                // just connected client
                _workerSocket.Add(newSession.ID, newSession);

                // Since the main Socket is now free, it can go back and wait for
                // other clients who are attempting to connect
                _mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                System.Diagnostics.Debugger.Log(0, "1", se.Message);
            }
        }

    }
}
