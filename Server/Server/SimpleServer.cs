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
        //--Loops through all the clients and sends them the message (basicly forwarding the message on)---//
        //-------------------------------------------------------------------------------------------------//

        void MessageGroup(string input, Client Sender)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (Sender.ServerLocation == _clients[i].ServerLocation)
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

        //------------if its an empty message it sents it to 4 char long to prevent null pointers----------//    
            if (input == "")
            {
                input = "    ";
            }
            string inputtemp = input.ToLower();
            string tempString = "";

        //--------ssi Server Select Input sets the new server input to decide what chat you are in---------//
            if (inputtemp[0] == 's' && inputtemp[1] == 's' && inputtemp[2] == 'i') //server selected index
            {
                if (client.NameOfUser != "New User") //checks if the user has enterd a name
                {
                    input = input.Substring(3); //takes of the key phrase of ssi
                    for (int i = 0; i < input.Length; i++)
                    {
                        if (input[i] == '|')
                        {
                            tempString = input.Remove(i, input.Length - i); //separates the input 
                            input = input.Substring(i + 1);
                        }
                    }
                    client.ServerLocation = int.Parse(input); //parses the string input to an int data form
                    ServerLog("You Have Been Switched to " + tempString, client);
                }
                else
                {
                    ServerLog("Please Enter A Name", client); //error message if name isnt set to prevent glitches
                }
            }
        //------------------------------------Area for changing the name-----------------------------------//
            else if (inputtemp[0] == 'n' && inputtemp[1] == 'a' && inputtemp[2] == 'm' && inputtemp[3] == 'e')
            {
                bool newName = false;
                input = input.Substring(5);
                if (input != client.NameOfUser)
                {
                    client.NameOfUser = input;
                    newName = true;
                }
                string UsersOnline = "on|";
                for (int i = 0; i < _clients.Count; i++)
                {
                    UsersOnline += _clients[i].NameOfUser + "|";
                }
                for (int j = 0; j < _clients.Count; j++)
                {
                    _clients[j].writer.WriteLine(UsersOnline);
                    if (newName == true)
                    {
                        if (_clients[j].NameOfUser == client.NameOfUser)
                        {
                            ServerLog("----------------------------Nick Name Changed----------------------------", _clients[j]);
                        }
                        else
                        {
                            ServerLog("-----------------A New User Has Joined The Channel------------------", _clients[j]);
                        }
                    }
                    else
                    {
                        ServerLog("un", _clients[j]);
                    }
                }

            }
        //--------------------------------------------Error Messages---------------------------------------//
            else if (client.NameOfUser == "New User")
            {
                ServerLog("To Message Anyone PLease Enter a name on the top left box:", client);
            }
            else if (client.NameOfUser != "New User")
            {
                if (inputtemp[0] == 's' && inputtemp[1] == 'e' && inputtemp[2] == 'r' && inputtemp[3] == 'v' && inputtemp[4] == 'e' && inputtemp[5] == 'r')
                {
                    //-- input.Replace() removes the command keywords  --//
                    inputtemp = inputtemp.Substring(7);
                    switch (inputtemp) // logistic of Inputs
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

                        case "help":
                            ServerLog("Comands Are 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , Help , Shut Down , Clear ServerLog", client);
                            break;

                        case "shut down":
                            ServerLog("Server Is Shutting itself down Now", client);
                            break;

                        case "clear serverLog":
                            Console.Clear();
                            ServerLog("Logs have been cleared", client);
                            break;

                        default:
                            ServerLog("Error With Transmittion / Exixuting command", client);
                            break;

                    }
                }
                else
                {
                    MessageGroup(input, client);
                }
            }
        //------------------------------------------Server Commands----------------------------------------//
            else
            {
                ServerLog("enter a message", client);
            }
            

        }

        //-------------------------------------------------------------------------------------------------//
        //--I Created the ServerLog function to allow a report of all actvities on the chat room for mods--//
        //-------------------------------------------------------------------------------------------------//

        void ServerLog(string input, Client client)
        {
            Console.WriteLine("Message: " + input + " Message Sent At: " + DateTime.Now.ToString("h:mm:ss tt")); //This allows a server log to be created
            client.writer.WriteLine(input);
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
        public int ServerLocation;

        public Client(Socket socketPassIn)
        {
            NameOfUser = "New User";
            ServerLocation = 10;
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