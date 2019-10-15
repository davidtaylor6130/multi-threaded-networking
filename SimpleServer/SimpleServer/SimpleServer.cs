using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SimpleServer
{

    class SimpleServer
    {
        StreamReader reader;
        StreamWriter writer;
        NetworkStream stream;
        List<Client> _clients;

        public TcpListener tcpListener = null;

        public SimpleServer(string ipAddress, int port)
        {
            tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
            _clients = new List<Client>();
        }

        public void Start()
        {
            tcpListener.Start();
            do
            {
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


        public void ClientMethod(object obj)
        {
            Client client = (Client)obj;
            string receivedMessage;

            client.writer.WriteLine("Connection Made....");
            client.writer.Flush();

            Thread thread = new Thread(new ParameterizedThreadStart(timeRepy));
            thread.Start(client);

            while ((receivedMessage = client.reader.ReadLine()) != null)
            {
                if (receivedMessage[0] == 'p' && receivedMessage[1] == 'u' && receivedMessage[2] == 'b' && receivedMessage[3] == ' ')
                {
                    for (int i = 0; i < _clients.Count; i++)
                    {
                        MessageGroup(receivedMessage, _clients[i]);
                    }
                }
                else
                {
                    GetReturnMessage(receivedMessage, client);
                }
                if (receivedMessage == "Shut Down")
                {
                    break;
                }

            }
            client.socket.Close();
            _clients.Remove(client);
        }

        void MessageGroup(string input, Client client)
        {
            client.writer.WriteLine(input);
            client.writer.Flush();
        }

        void GetReturnMessage(string input, Client client)
        {

                switch (input)
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
                        ServerLog("Error With Transmittion / Exixuting command", client);
                        break;

                }
            
        }

        void ServerLog(string input, Client client)
        {
            Console.WriteLine("Message: " + input + " Message Sent At: " + DateTime.Now.ToString("h:mm:ss tt"));
            client.writer.WriteLine(input);
            client.writer.Flush();
        }

        void timeRepy(object obj)
        {
            Client client = (Client)obj;
            for (int i = 0; i < 10; i++)
            {
                client.writer.WriteLine("test");
                client.writer.Flush();
            }
        }
    }

    class Client
    {
        public Socket socket;
        public NetworkStream stream;
        public StreamReader reader { get; private set; }
        public StreamWriter writer { get; private set; }

        public Client(Socket socketPassIn)
        {
            socket = socketPassIn;
            stream = new NetworkStream(socketPassIn);
            reader = new StreamReader(stream, Encoding.UTF8);
            writer = new StreamWriter(stream, Encoding.UTF8);
        }

        public void Close()
        {
            socket.Close();
        }
    }

}
