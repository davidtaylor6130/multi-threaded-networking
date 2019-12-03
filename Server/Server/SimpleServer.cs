using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using Packets;

namespace SimpleServer
{

    class SimpleServer
    {
        List<Client> _clients;
        public TcpListener tcpListener = null;
        MemoryStream ms;
        BinaryFormatter bf;
        string ipAddress;
        int port;

        //-------------------------------------------------------------------------------------------------//
        //--Creates a new tcpListerner to listen in for incoming trafic to the passed in ipadress and port-//
        //-------------------------------------------------------------------------------------------------//

        public SimpleServer(string ipAddressPassIn, int portPassIn)
        {
            ipAddress = ipAddressPassIn;
            port = portPassIn;
            tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
            _clients = new List<Client>();
        }

        //-------------------------------------------------------------------------------------------------//
        //---------Thre Start Function creates a new client class and saves it to the _clients List--------//
        //---Once the conection is made the tread is started and clients the current client has been pass--//
        //--------------------------------------- into the thread -----------------------------------------//
        //-------------------------------------------------------------------------------------------------//

        public void Start()
        {
            tcpListener.Start();
            do
            {
                ms = new MemoryStream();
                bf = new BinaryFormatter();

                Socket socket = tcpListener.AcceptSocket();

                Console.WriteLine("Connection Established");
                Client _clientsTemp = new Client(socket);
                _clients.Add(_clientsTemp);

                Thread t = new Thread(new ParameterizedThreadStart(ClientMethod));
                t.Start(_clientsTemp);

            } while (_clients.Count > 0);
            Stop();
        }

        public void Stop()
        {
            tcpListener.Stop();
        }

        //-------------------------------------------------------------------------------------------------//
        //-The Client Method is independent per client running on multiple threads this allow for multiple-//
        //-------------------- Clients to be connected and communicate with the server --------------------//
        //-------------------------------------------------------------------------------------------------//

        public void UDPCLientMethod(Object clientObj)
        {
            Client client = (Client) clientObj;
            try
            {
                while(client.UdpConnected())
                {
                    GetReturnMessage(client.UdpRead(), client);
                }
            }
            catch (Exception e)
            {
               Console.WriteLine(e);
            }
        }

        public void ClientMethod(object obj)
        {
            Client client = (Client)obj;
            Packet packet;

            while (client.TcpConnected())
            {
                if ((packet = client.TcpRead()) != null)
                {
                    GetReturnMessage(packet, client);
                }
            }
            client.Close();
            _clients.Remove(client);
        }

        //-------------------------------------------------------------------------------------------------//
        //---The MessageGroup function sends a message to everyone in the server apart from who sent it----//
        //--Loops through all the clients and sends them the message (basicly forwarding the message on)---//
        //-------------------------------------------------------------------------------------------------//

        void MessageGroup(Packet input, Client Sender)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (Sender.ServerLocation == _clients[i].ServerLocation)
                {
                    _clients[i].TcpSend(input);
                }
            }
        }

        //-------------------------------------------------------------------------------------------------//
        //---GetReturnMessage Function is the brains of the server this gives the output from the input----//
        //--------------------------of the users this also calles server log-------------------------------//
        //-------------------------------------------------------------------------------------------------//

        void GetReturnMessage(Packet packetInput, Client client)
        {
            string input = "";
            switch (packetInput.Type)
            {
                case PacketType.ServerLocation:

                    //--------------------------------------------------------------------------------------------------------------//
                    //---------------------------------------------------For Chat Clients-------------------------------------------//
                    //--------------------------------------------------------------------------------------------------------------//
                    // casting the input packet to the correct type
                    ServerLocationPacket ServerLocation = (ServerLocationPacket) packetInput;
                    if (client.NameOfUser != "New User") //checks if the user has enterd a name
                    {
                        client.ServerLocation = ServerLocation.serverLocation; //parses the string input to an int data form
                        ServerLog("You Have Been Switched to " + ServerLocation.ServerName, client);
                    }
                    else
                    {
                        ServerLog("Please Enter A Name", client); //error message if name isnt set to prevent glitches
                    }

                    //--------------------------------------------------------------------------------------------------------------//
                    //-----------------------Initalised checkers games and prevents more than 2 players-----------------------------//
                    //--------------------------------------------------------------------------------------------------------------//

                    if (ServerLocation.serverLocation >= 5 && ServerLocation.serverLocation <= 8)
                    {
                        int ammountPlayingGame = 0;
                        for (int i = 0; i < _clients.Count; i++)
                        {
                            if (_clients[i].ServerLocation == client.ServerLocation)
                            {
                                ammountPlayingGame++;
                            }
                        }

                        if (ammountPlayingGame <= 2)
                        {
                            Client Gamer1 = null;
                            Client Gamer2 = null;
                            int locationIn_clients1 = -99;
                            int locationIn_clients2 = -99;

                            for (int i = 0; i < _clients.Count; i++)
                            {
                                if (client.ServerLocation == _clients[i].ServerLocation)
                                {
                                    if (Gamer1 == null)
                                    {
                                        Gamer1 = _clients[i];
                                        locationIn_clients1 = i;
                                    }
                                    else if (Gamer2 == null)
                                    {
                                        Gamer2 = _clients[i];
                                        locationIn_clients2 = i;
                                    }
                                }

                                if (Gamer1 != null && Gamer2 != null)
                                {
                                    Packet temp = new GameConnectionPacket(true, Gamer1.NameOfUser, Gamer2.NameOfUser);
                                    Gamer1.TcpSend(temp);
                                    Gamer2.TcpSend(temp);

                                    if (Gamer1 == client)
                                    {
                                        client.gameVs = Gamer2.NameOfUser;
                                        _clients[locationIn_clients2].gameVs = Gamer1.NameOfUser;
                                    }
                                    else if (Gamer2 == client)
                                    {
                                        client.gameVs = Gamer1.NameOfUser;
                                        _clients[locationIn_clients1].gameVs = Gamer2.NameOfUser;
                                    }
                                }
                            }
                        }
                        else
                        {
                            client.ServerLocation = 1;
                            Packet dataPacket = new ServerMessagePacket("ChatRoom Full You Have Been Moved to Server 1");
                            client.TcpSend(dataPacket);
                        }
                    }

                    //--------------------------------------------------------------------------------------------------------------//
                    //------------------------------------------Initalising server text game----------------------------------------//
                    //--------------------------------------------------------------------------------------------------------------//

                    if (ServerLocation.serverLocation >= 8 && ServerLocation.serverLocation <= 9)
                    {
                        int ammountPlayingGame = 0;
                        for (int i = 0; i < _clients.Count; i++)
                        {
                            if (_clients[i].ServerLocation == client.ServerLocation)
                            {
                                ammountPlayingGame++;
                            }
                        }

                        if (ammountPlayingGame <= 1)
                        {
                            Packet dataPacket = new ServerMessagePacket("The Rock Paper Scissors Selected");
                            client.TcpSend(dataPacket);
                        }
                        else
                        {
                            client.ServerLocation = 1;
                            Packet dataPacket = new ServerMessagePacket("ChatRoom Full You Have Been Moved to Server 1");
                            client.TcpSend(dataPacket);
                        }
                    }
                    break;

                case PacketType.NickName:

                    //casting input to nicknamePacket for use
                    NickNamePacket NickName = (NickNamePacket)packetInput;
                    bool sameName = false;
                    int sameNameAmount = 0;

                    for (int i = 0; i < _clients.Count; i++)
                    {
                        if (NickName.Name[0] == _clients[i].NameOfUser)
                        {
                            sameName = true;
                            sameNameAmount++;
                        }
                    }

                    if (sameName == true)
                    {
                        NameInUsePacket nameInUse = new NameInUsePacket(true);
                        client.TcpSend(nameInUse);
                    }
                    else
                    {
                        NameInUsePacket nameInUse = new NameInUsePacket(false);
                        client.TcpSend(nameInUse);
                        client.NameOfUser = NickName.Name[0];


                        NickNamePacket SendPacket = new NickNamePacket(client.NameOfUser, 0);

                        for (int i = 0; i < SendPacket.Name.Length; i++)
                        {
                            if (SendPacket.Name[i] == null)
                                SendPacket.Name[i] = " ";
                            if (i < _clients.Count)
                                SendPacket.Name[i] = _clients[i].NameOfUser;
                        }

                        for (int j = 0; j < _clients.Count; j++)
                        {
                            _clients[j].TcpSend(SendPacket);
                            if (_clients[j].NameOfUser == client.NameOfUser)
                            {
                                ServerLog("----------------------Nick Name Changed-----------------------",
                                    _clients[j]);
                            }
                            else
                            {
                                ServerLog("-----------A New User Has Joined The Channel-------------",
                                    _clients[j]);
                            }
                        }
                    }

                    break;

                case PacketType.ServerCommand:
                    ServerCommand serverCommand = (ServerCommand) packetInput;
                    input = serverCommand.CommandToServer;
                    //-- input.Replace() removes the command keywords  --//
                    input = input.Substring(1);
                    switch (input) // logistic of Inputs
                    {
                        case "1":
                            ServerLog("1 Has Been Pressed", client);
                            break;
                        case "2":
                            ServerLog("2 Has Been Pressed", client);
                            break;
                        case "3":
                            ServerLog("3 Has Been Pressed", client);
                            break;
                        case "4":
                            ServerLog("4 Has Been Pressed", client);
                            break;
                        case "5":
                            ServerLog("5 Has Been Pressed", client);
                            break;
                        case "6":
                            ServerLog("6 Has Been Pressed", client);
                            break;
                        case "7":
                            ServerLog("7 Has Been Pressed", client);
                            break;
                        case "8":
                            ServerLog("8 Has Been Pressed", client);
                            break;
                        case "9":
                            ServerLog("9 Has Been Pressed", client);
                            break;

                        // <-------------------------------------COMMANDS SECTION----------------------------------->

                        case "Help":
                            ServerLog("Comands Are 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , Help , Shut Down , Clear ServerLog", client);
                            break;

                        case "Shut Down":
                            ServerLog("Server Is Shutting itself down Now", client);
                            break;

                        case "Clear ServerLog":
                            Console.Clear();
                            ServerLog("Logs have been cleared", client);
                            break;

                        default:
                            ServerLog("Error With Transmittion / Exixuting command try /Help", client);
                            break;

                    }
                    break;

                case PacketType.ChatMessage:
                    if (client.NameOfUser != "New User")
                    {
                        ChatMessagePacket chatMessagePacket = (ChatMessagePacket) packetInput;
                        if (chatMessagePacket.To == "Server")
                            MessageGroup(packetInput, client);
                        else
                        {
                            for (int i = 0; i < _clients.Count; i++)
                            {
                                if (_clients[i].NameOfUser == chatMessagePacket.To)
                                {
                                    _clients[i].TcpSend(packetInput);
                                }
                            }
                        }
                    }
                    else
                    {
                        ServerMessagePacket serverMessagePacket = new ServerMessagePacket("Please Enter A Name");
                        client.TcpSend(serverMessagePacket);
                    }

                    break;

                case PacketType.EndPointPacket:
                    EndPointPacket packet = (EndPointPacket)packetInput;
                    client.CreateUdpConnection(packet, ipAddress, port);
                    Console.WriteLine("UDP PACKET RECIVED");
                    Thread t = new Thread(new ParameterizedThreadStart(UDPCLientMethod));
                    t.Start(client);

                    break;

                case PacketType.TurnToggle:
                    TurnToggle togglePacket = (TurnToggle) packetInput;
                    for (int i = 0; i < _clients.Count; i++ )
                    {
                        if (_clients[i].NameOfUser == togglePacket.WhosTurn)
                        {
                            _clients[i].UdpSend(packetInput);
                        }
                    }
                    break;

                case PacketType.GamePacket:
                    GamePacket gamePacket = (GamePacket) packetInput;
                    for (int i = 0; i < _clients.Count; i++)
                    {
                        if (_clients[i].NameOfUser == client.gameVs)
                        {
                            _clients[i].UdpSend(gamePacket);
                        }
                    }
                    Console.WriteLine(client.NameOfUser + ":" +  client.gameVs);
                    break;

                case PacketType.RockPaperScissors:

                    // 1-rock
                    // 2-paper
                    // 3-scissor

                    ServerMessagePacket Response = new ServerMessagePacket("Please Enter ROCK, PAPER, SCISSOR");
                    RockPaperScissors rockPaperScissors = (RockPaperScissors) packetInput;

                    if (rockPaperScissors.Selection == "ROCK" || rockPaperScissors.Selection == "PAPER"|| rockPaperScissors.Selection == "SCISSOR")
                    { 
                        Random random = new Random();
                        int randomNumber = random.Next(1, 4);

                        switch (randomNumber)
                        {
                            case 1:
                                Response.message = "Rock Selected";
                                client.TcpSend(Response);
                                if (rockPaperScissors.Selection == "ROCK") { Response.message = "We Tie"; }
                                if (rockPaperScissors.Selection == "PAPER") { Response.message = "You Win"; }
                                if (rockPaperScissors.Selection == "SCISSOR") { Response.message = "You Lose"; }
                                break;
                            case 2:
                                Response.message = "Paper Selected";
                                client.TcpSend(Response);
                                if (rockPaperScissors.Selection == "ROCK") { Response.message = "You Win"; }
                                if (rockPaperScissors.Selection == "PAPER") { Response.message = "We Tie"; }
                                if (rockPaperScissors.Selection == "SCISSOR") { Response.message = "You Lose"; }
                                break;
                            case 3:
                                Response.message = "Scissor Selected";
                                client.TcpSend(Response);
                                if (rockPaperScissors.Selection == "ROCK") { Response.message = "You Lose"; }
                                if (rockPaperScissors.Selection == "PAPER") { Response.message = "You Win"; }
                                if (rockPaperScissors.Selection == "SCISSOR") { Response.message = "We Tie"; }
                                break;
                        }
                    }
                    else
                    {
                        Response.message = "Please Enter ROCK, PAPER, SCISSOR";
                    }

                    client.TcpSend(Response);
                    break;
            }
            

        }

        //-------------------------------------------------------------------------------------------------//
        //--I Created the ServerLog function to allow a report of all actvities on the chat room for mods--//
        //-------------------------------------------------------------------------------------------------//

        void ServerLog(string input, Client client)
        {
            Console.WriteLine("Message: " + input + " Message Sent At: " + DateTime.Now.ToString("h:mm:ss tt")); //This allows a server log to be created
            ServerMessagePacket packet = new ServerMessagePacket(input);
            client.TcpSend(packet);
        }
    }

    //-------------------------------------------------------------------------------------------------//
    //--The Client Class is used to have information about the client that is saved like there reader--//
    //-writer and their network stream i have also added a name to each client for easy identification-//
    //-------------------------------------------------------------------------------------------------//

    class Client
    {
        public UdpClient _UdpClient;
        public Socket TcpSocket;
        public Socket UdpSocket;
        public NetworkStream _TcpStream;
        public NetworkStream _UdpStream;
        public BinaryReader _TcpReader { get; private set; }
        public BinaryWriter _TcpWriter { get; private set; }
        public BinaryReader _UdpReader { get; private set; }
        public BinaryWriter _UdpWriter { get; private set; }

        public MemoryStream ms { get; private set; }
        public BinaryFormatter bf { get; private set; }

        public string NameOfUser;
        public string gameVs;
        public int ServerLocation;

        public Client(Socket socketPassIn)
        {
            NameOfUser = "New User";
            ServerLocation = 10;
            gameVs = null;

            TcpSocket = socketPassIn;
            UdpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            _TcpStream = new NetworkStream(socketPassIn);
            _TcpReader = new BinaryReader(_TcpStream, Encoding.UTF8);
            _TcpWriter = new BinaryWriter(_TcpStream, Encoding.UTF8);
            ms = new MemoryStream();
            bf = new BinaryFormatter();
        }

        public void CreateUdpConnection(EndPointPacket packet, string ipAddressPassIn, int port)
        { 
            UdpSocket.Connect(packet.endPoint);
            Packet SendPacket = new EndPointPacket(UdpSocket.LocalEndPoint);
            TcpSend(SendPacket);
        }

        public Packet TcpRead()
        {
            int noOfIncomingBytes = 0;
            if ((noOfIncomingBytes = _TcpReader.ReadInt32()) != 0)
            {
                byte[] buffer = _TcpReader.ReadBytes(noOfIncomingBytes);
                ms = new MemoryStream();
                ms.Write(buffer, 0, noOfIncomingBytes);
                ms.Position = 0;
                Packet packet = bf.Deserialize(ms) as Packet;
                ms.SetLength(0);
                ms.Capacity = 0;
                return packet;
            }
            return null;
        }

        public void TcpSend(Packet data)
        {
            ms = new MemoryStream();
            bf.Serialize(ms, data);
            ms.Position = 0;
            byte[] buffer = ms.GetBuffer();

            _TcpWriter.Write(buffer.Length);
            _TcpWriter.Write(buffer);
            _TcpWriter.Flush();
        }

        public Packet UdpRead()
        {
            int noOfIncomingBytes = 0;
            byte[] bytes = new byte[1024*1024];
            if ((noOfIncomingBytes = UdpSocket.Receive(bytes)) != 0)
            { 
                ms = new MemoryStream(bytes);
                Packet packet = bf.Deserialize(ms) as Packet;
                return packet;
            }
            return null;
        }

        public void UdpSend(Packet data)
        {
            ms = new MemoryStream();
                bf.Serialize(ms, data);
                ms.Position = 0;
                byte[] buffer = ms.GetBuffer();
                UdpSocket.Send(buffer);
        }

        public bool TcpConnected()
        {
            if (_TcpReader != null)
            {
                return true;
            }
            return false;
        }

        public void Close()
        {
            TcpSocket.Close();
        }

        public bool UdpConnected()
        {
            return UdpSocket.Connected;
        }
    }

}