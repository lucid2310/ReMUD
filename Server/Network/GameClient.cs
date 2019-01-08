using ReMUD.Game;
using ReMUD.Game.Structures;
using ReMUD.Server.Managers;
using ReMUD.Server.Pages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;

namespace ReMUD.Server.Network
{
    public class GameClient
    {
        private GameManager _gameManager { get; set; }
        public Socket UserConnection { get; set; }
        public PlayerType Player { get; set; }
        public AsyncCallback pfnWorkerCallBack;
        public string ID { get; set; }
        public Func<string, int> DisconnectHandler { get; set; }
        public String InputBuffer = string.Empty;
        public Terminal ClientTerminal { get; set; }
        public PageStates CurrentState = PageStates.Login;
        public Queue<string> CommandQueue = new Queue<string>();
        public Dictionary<PageStates, BasePage> Pages = new Dictionary<PageStates, BasePage>();
    
        public GameClient(Socket connection, GameManager gManager, Func<string, int> disconnectMethod)
        {      
            _gameManager = gManager;
     
            ID = Guid.NewGuid().ToString();
            UserConnection = connection;
            IPEndPoint iPEndPoint = (IPEndPoint)UserConnection.RemoteEndPoint;

            //byte[] t = GameServer.GetMacAddress(iPEndPoint.Address);
           // string mac = string.Join(":", (from z in t select z.ToString("X2")).ToArray());
           // Console.WriteLine("{0} has connectd with MAC Address {1}", ID, mac);
            DisconnectHandler = disconnectMethod;       
            WaitForData(UserConnection);

            Pages.Add(PageStates.Login, new LoginPage(this));
            Pages.Add(PageStates.Menu, new MenuPage(this));
            Pages.Add(PageStates.Game, new GamePage(this));

            Pages[PageStates.Login].Load();
        }
   
        // Start waiting for data from the client
        public void WaitForData(System.Net.Sockets.Socket socket)
        {
            try
            {
                if(IsConnected(socket) == false)
                {
                    socket.Disconnect(false);
                    socket.Dispose();
                    Console.WriteLine("{0} has disconnected.", ID);
                    DisconnectHandler(ID);
                    return;
                }

                if (pfnWorkerCallBack == null)
                {
                    // Specify the call back function which is to be 
                    // invoked when there is any write activity by the 
                    // connected client
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }

                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.CurrentSocket = socket;
                // Start receiving any data written by the connected client
                // asynchronously
                socket.BeginReceive(theSocPkt.DataBuffer, 0,
                                   theSocPkt.DataBuffer.Length,
                                   SocketFlags.None,
                                   pfnWorkerCallBack,
                                   theSocPkt);
            }
            catch (SocketException se)
            {
                //MessageBox.Show(se.Message);
            }

        }

        public static bool IsConnected(Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException) { return false; }
        }

        public void Send(byte[] data)
        {
            // Begin sending the data to the remote device.  
            UserConnection.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), UserConnection);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Update()
        {
            if (Pages[CurrentState].MoveToNext == true)
            {
                CurrentState = Pages[CurrentState].NextPage;
                Pages[CurrentState].Load();
            }
        }

        // This the call back function which will be invoked when the socket
        // detects any client writing of data on the stream
        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket socketData = (SocketPacket)asyn.AsyncState;

                // Complete the BeginReceive() asynchronous call by EndReceive() method
                // which will return the number of characters written to the stream 
                // by the client
                int iRx = socketData.CurrentSocket.EndReceive(asyn);

                switch(socketData.DataBuffer[0])
                {
                    case 0x0A:
                    case 0x0D:
                        Pages[CurrentState].Process(InputBuffer);

                        InputBuffer = string.Empty;

                        Update();
                        break;
                    case 0x08:
                        if (InputBuffer.Length > 0)
                        {
                            InputBuffer = InputBuffer.Substring(0, InputBuffer.Length - 1);

                            if (Pages[CurrentState].EnableMask == false)
                            {
                                Send(socketData.DataBuffer);
                            }
                            else
                            {
                                Send(Pages[CurrentState].MaskCharacter);
                            }
                        }
                        break;
                    default:
                        InputBuffer += (char)socketData.DataBuffer[0];

                        if (Pages[CurrentState].EnableMask == false)
                        {
                            Send(socketData.DataBuffer);
                        }
                        else
                        {
                            Send(Pages[CurrentState].MaskCharacter);
                        }

                        break;
                }            

                WaitForData(socketData.CurrentSocket);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                System.Diagnostics.Debugger.Log(0, "1", se.Message);
            }
        }
    }
}
