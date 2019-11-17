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
        private TcpClient tcpClient;
        private NetworkStream TcpStream;
        private NetworkStream UdpStream;
        private Thread thread;
        private ClientForm messageForm;

        private Socket UdpSocket;

        private BinaryWriter _writer;
        private BinaryReader _reader;
        private MemoryStream ms;
        private BinaryFormatter bf;

        //-------------------------------------------------------------------------------------------------//
        //------------------Simple Client creates a new tcpClient for the client to use---------------------//
        //-------------------------------------------------------------------------------------------------//

        public SimpleClient()
        {
            tcpClient = new TcpClient();
            messageForm = new ClientForm(this);
        }

        //-------------------------------------------------------------------------------------------------//
        //---Connect passes in the idAdress and port of the server and trys to connect with UTF8 Encoding--//
        //------------if not possible to connect for any reasion it will output an error message-----------// 
        //-------------------------------------------------------------------------------------------------//

        public bool Connect(string ipAddress, int port)
        {
            try
            {
                tcpClient.Connect(IPAddress.Parse(ipAddress), port);
                TcpStream = tcpClient.GetStream();

                _writer = new BinaryWriter(TcpStream, Encoding.UTF8);
                _reader = new BinaryReader(TcpStream, Encoding.UTF8);
                ms = new MemoryStream();
                bf = new BinaryFormatter();

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

        public void Send(Packet data)
        {
            ms.SetLength(0);
            ms.Capacity = 0;
            bf.Serialize(ms,data);
            ms.Position = 0;
            byte[] buffer = ms.GetBuffer();

            _writer.Write(buffer.Length);
            _writer.Write(buffer);
            _writer.Flush();
        }

        //-------------------------------------------------------------------------------------------------//
        //----ProsessServerResponce Handels the unexspected output from the server like public messages----// 
        //-------------------------------------------------------------------------------------------------//

        void ProcessServerResponce()
        {
            int noOfIncomingBytes = 0;
            while ((noOfIncomingBytes = _reader.ReadInt32()) != 0)
            {
                byte[] buffer = _reader.ReadBytes(noOfIncomingBytes);
                ms.Write(buffer, 0, noOfIncomingBytes);
                ms.Position = 0;
                //ms.Seek(0, SeekOrigin.Begin);
                bf.Binder = new AllowAllAssemblyVersionsDeserializationBinder();
                Packet packet = bf.Deserialize(ms) as Packet;
                ms.SetLength(0);
                ms.Capacity = 0;

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
                        EndPointPacket endPointPacket = (EndPointPacket)packet;
                        UdpSocket.Connect(endPointPacket.endPoint);
                        break;
                    default:

                        break;
                }
                packet = null;
            }
        }
    }
}
