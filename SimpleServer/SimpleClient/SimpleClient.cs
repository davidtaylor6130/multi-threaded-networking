using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SimpleClient
{
    class SimpleClient
    {

        //-------------------------------------------------------------------------------------------------//
        //----------------------------------Desclration of public Verables---------------------------------//
        //-------------------------------------------------------------------------------------------------//

        public string userInput = null;
        private TcpClient tcpClient;
        private NetworkStream stream;
        private StreamWriter writer;
        private StreamReader reader;

        //-------------------------------------------------------------------------------------------------//
        //------------------Simple Client creates a new tcpClient for the client to use---------------------//
        //-------------------------------------------------------------------------------------------------//

        public SimpleClient()
        {
               tcpClient = new TcpClient();   
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
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8);
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

            Thread thread = new Thread(ProcessServerResponce);
            thread.Start();

            Console.WriteLine("Please Enter you Messaging Name: ");
            userInput = Console.ReadLine();
            userInput = "name " + userInput;
            writer.WriteLine(userInput);
            writer.Flush();

            while ((userInput = Console.ReadLine()) != null)
            {
                writer.WriteLine(userInput);
                writer.Flush();

                if (userInput == "Shut Down")
                {
                    Console.WriteLine("Client shutting down");
                    break;
                }

                //--reader.Peek() sees if the server has sent anything back if it does it outputs it to screen--//

                if (reader.Peek() != -1) 
                {
                    Console.WriteLine("Server says: "+ reader.ReadLine());
                }
            }
            tcpClient.Close();
            Console.ReadLine();
        }

        //-------------------------------------------------------------------------------------------------//
        //----ProsessServerResponce Handels the unexspected output from the server like public messages----// 
        //-------------------------------------------------------------------------------------------------//

        void ProcessServerResponce()
        {
            string testTemp;
            while (true)
            {
                testTemp = reader.ReadLine();
                Console.WriteLine(testTemp);
                if (userInput == "Shut Down")
                {
                    break;
                }
            }

        }
    }
}
