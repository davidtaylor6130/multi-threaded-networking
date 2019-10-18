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

        //-------------------------------------------------------------------------------------------------//
        //--Creates a new tcpListerner to listen in for incoming trafic to the passed in ipadress and port-//
        //-------------------------------------------------------------------------------------------------//

        public SimpleServer(string ipAddress, int port)
        {
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

        public void ClientMethod(object obj)
        {
            Client client = (Client)obj;
            string receivedMessage;

            client.writer.WriteLine("Connection Made....");
            client.writer.Flush();

            while ((receivedMessage = client.reader.ReadLine()) != null)
            {
                    GetReturnMessage(receivedMessage, client);

                if (receivedMessage == "Shut Down")
                {
                    break;
                }

            }
            client.socket.Close();
            _clients.Remove(client);
        }

        //-------------------------------------------------------------------------------------------------//
        //---The MessageGroup function sends a message to everyone in the server apart from who sent it----//
        //-------------------------------------------------------------------------------------------------//

        void MessageGroup(string input, Client Sender)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (Sender.NameOfUser != _clients[i].NameOfUser)
                {
                    _clients[i].writer.WriteLine(Sender.NameOfUser + ": " + input);
                    _clients[i].writer.Flush();
                }
            }
        }

        //-------------------------------------------------------------------------------------------------//
        //---GetReturnMessage Function is the brains of the server this gives the output from the input----//
        //--------------------------of the users this also calles server log-------------------------------//
        //-------------------------------------------------------------------------------------------------//

        void GetReturnMessage(string input, Client client)
        {
            if (input[0] == 'p' && input[1] == 'u' && input[2] == 'b' && input[3] == ' ')
            {
                //-- input.Replace() removes the command keywords  --//
                input = input.Replace("pub ", "");
                MessageGroup(input, client);
            }
            else if (input[0] == 'n' && input[1] == 'a' && input[2] == 'm' && input[3] == 'e')
            {
                //-- input.Replace() removes the command keywords  --//
                input = input.Replace("name", "");
                client.NameOfUser = input;
            }
            else if (input[0] == 'g' && input[1] == 'a' && input[2] == 'm' && input[3] == 'e')
            {
                input = input.Replace("game", "");
                ServerLog("Game Has Been Selected", client);
            }
            else
            {
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
                        ServerLog("Error With Transmittion / Exixuting command", client);
                        break;

                }
            }
        }

        //-------------------------------------------------------------------------------------------------//
        //--I Created the ServerLog function to allow a report of all actvities on the chat room for mods--//
        //-------------------------------------------------------------------------------------------------//

        void ServerLog(string input, Client client)
        {
            Console.WriteLine("Message: " + input + " Message Sent At: " + DateTime.Now.ToString("h:mm:ss tt")); //This allows a server log to be created
            client.writer.WriteLine("Server says: " + input);
            client.writer.Flush();
        }

    }


    //-------------------------------------------------------------------------------------------------//
    //--The Client Class is used to have information about the client that is saved like there reader--//
    //-writer and their network stream i have also added a name to each client for easy identification-//
    //-------------------------------------------------------------------------------------------------//

    class Client
    {
        public Socket socket;
        public NetworkStream stream;
        public StreamReader reader { get; private set; }
        public StreamWriter writer { get; private set; }
        public string NameOfUser;

        public Client(Socket socketPassIn)
        {
            NameOfUser = null;
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
