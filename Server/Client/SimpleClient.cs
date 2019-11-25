using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Client;
using Packets;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleClient
{
    public class SimpleClient
    {

        //-------------------------------------------------------------------------------------------------//
        //----------------------------------Desclration of public Verables---------------------------------//
        //-------------------------------------------------------------------------------------------------//

        public bool ShutDown = false;
        public int clientLocation = 11;

        private string IpAdressGlobal;
        private int port;

        private TcpClient tcpClient;
        private UdpClient UdpClient;

        private Socket UdpSocket;
        private NetworkStream TcpStream;
        private NetworkStream UdpStream;
        private BinaryWriter _TcpWriter;
        private BinaryReader _TcpReader;
        private BinaryWriter _UdpWriter;
        private BinaryReader _UdpReader;
        private MemoryStream ms;
        private BinaryFormatter bf;

        private Thread thread;
        private ClientForm messageForm;
        public CheckersGame game;

        //-------------------------------------------------------------------------------------------------//
        //------------------Simple Client creates a new tcpClient for the client to use---------------------//
        //-------------------------------------------------------------------------------------------------//

        public SimpleClient()
        {
            tcpClient = new TcpClient();
            UdpClient = new UdpClient();
            messageForm = new ClientForm(this);
            game = new CheckersGame(this);
        }

        //-------------------------------------------------------------------------------------------------//
        //---Connect passes in the idAdress and port of the server and trys to connect with UTF8 Encoding--//
        //------------if not possible to connect for any reasion it will output an error message-----------// 
        //-------------------------------------------------------------------------------------------------//

        public bool Connect(string ipAddress, int portPassIn)
        {
            IpAdressGlobal = ipAddress;
            port = portPassIn;
            try
            {
                tcpClient.Connect(IPAddress.Parse(ipAddress), port);
                TcpStream = tcpClient.GetStream();
                UdpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Unspecified);
                _TcpWriter = new BinaryWriter(TcpStream, Encoding.UTF8);
                _TcpReader = new BinaryReader(TcpStream, Encoding.UTF8);
                ms = new MemoryStream();
                bf = new BinaryFormatter();

                UdpClient = new UdpClient();
                UdpClient.Connect(ipAddress,portPassIn);

                TcpSend(new EndPointPacket(UdpClient.Client.LocalEndPoint));

                //UDP CONNECT CLIENT THROUGH HOST NAMe AND PORT
                //TCP SEND THE CONNECT PACKET

                Application.Run(messageForm);
            }
            catch
            {
                Console.WriteLine("Cannot connect to:" + ipAddress + ":" + port + "sucsessfully");
                return false;
            }
            return true;
        }

        //-------------------------------------------------------------------------------------------------//
        //---Run Handels the Actual Loop of the client it sends the users input to the server and checks---//
        //-----------If the client runs the command Shut Down this exits the infinate while loop-----------//
        //-An Extra Thread is utalized to Prosees the servers random responses (like from public messages)-//
        //-------------------------------------------------------------------------------------------------//

        public void Run()
        {
            thread = new Thread(ProcessServerResponce);
            thread.Start();
        }

        public void Stop()
        {
            thread.Abort();
            tcpClient.Close();
        }

        public Packet TcpRead()
        {
            int noOfIncomingBytes = 0;
            if ((noOfIncomingBytes = _TcpReader.ReadInt32()) != 0)
            {
                byte[] buffer = _TcpReader.ReadBytes(noOfIncomingBytes);
                ms.SetLength(0);
                ms.Capacity = 0;
                ms.Write(buffer, 0, noOfIncomingBytes);
                ms.Position = 0;
                bf.Binder = new AllowAllAssemblyVersionsDeserializationBinder();
                Packet packet = bf.Deserialize(ms) as Packet;
                ms.SetLength(0);
                ms.Capacity = 0;
                return packet;
            }
            return null;
        }

        public void TcpSend(Packet data)
        {
            ms.SetLength(0);
            ms.Capacity = 0;
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
            if ((noOfIncomingBytes = _UdpReader.ReadInt32()) != 0)
            {
                byte[] buffer = _UdpReader.ReadBytes(noOfIncomingBytes);
                ms.SetLength(0);
                ms.Capacity = 0;
                ms.Write(buffer, 0, noOfIncomingBytes);
                ms.Position = 0;
                bf.Binder = new AllowAllAssemblyVersionsDeserializationBinder();
                Packet packet = bf.Deserialize(ms) as Packet;
                ms.SetLength(0);
                ms.Capacity = 0;
                return packet;
            }
            return null;
        }

        public void UdpSend(Packet data)
        { 
           ms.SetLength(0);
           ms.Capacity = 0;
           bf.Serialize(ms, data);
           ms.Position = 0;
           byte[] buffer = ms.GetBuffer();

           UdpClient.Send(buffer, buffer.Length);
        }

        public bool TcpConnected()
        {
            if (_TcpReader != null)
            {
                return true;
            }
            return false;
        }

        //-------------------------------------------------------------------------------------------------//
        //----ProsessServerResponce Handels the unexspected output from the server like public messages----// 
        //-------------------------------------------------------------------------------------------------//

        void ClientLogic(Packet packet)
        {
            switch (packet.Type)
            {
                case PacketType.ChatMessage:
                    ChatMessagePacket packetChatMessage = (ChatMessagePacket)packet;
                    messageForm.UpdateChatWindow(packetChatMessage.message);
                    break;
                case PacketType.DirectMessage:
                    break;
                case PacketType.NickName:
                    NickNamePacket packetUserList = (NickNamePacket)packet;
                    messageForm.updateWhosOnline(packetUserList);
                    break;
                case PacketType.ServerCommand:
                    break;
                case PacketType.ServerLocation:
                    break;
                case PacketType.ServerMessagePacket:
                    ServerMessagePacket packetServerMessage = (ServerMessagePacket)packet;
                    messageForm.UpdateChatWindow(packetServerMessage.message);
                    break;
                case PacketType.EndPointPacket:
                    EndPointPacket endPoint = (EndPointPacket) packet;
                    UdpClient.Connect((IPEndPoint)(endPoint.endPoint));
                    Thread t = new Thread(new ThreadStart(UDPServerResponce));
                    t.Start();
                    break;
                default:

                    break;
            }
        }

        void UDPServerResponce()
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    byte[] bytes = UdpClient.Receive(ref endPoint);

                    MemoryStream mem = new MemoryStream(bytes);
                    ms.SetLength(0);
                    ms.Capacity = 0;
                    ms.Write(bytes, 0, bytes.Length);
                    ms.Position = 0;
                    bf.Binder = new AllowAllAssemblyVersionsDeserializationBinder();
                    Packet packet = bf.Deserialize(ms) as Packet;
                    ms.SetLength(0);
                    ms.Capacity = 0;
                    ClientLogic(packet);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        void ProcessServerResponce()
        {
            Packet packet;
            while (TcpConnected())
            {
                if ((packet = TcpRead()) != null)
                {
                    ClientLogic(packet);
                }
            }
        }
    }
}
